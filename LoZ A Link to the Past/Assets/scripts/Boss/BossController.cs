using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BOSS_STATE
{
  K_FOLLOW_LINK,
  K_ATTACK,
  K_IDLE,
  K_CHARGE,
  K_STUNNED
}

public class BossController : MonoBehaviour
{
  public int damage = 2;

  public GameObject m_ball;

  public GameObject m_link;

  public GameObject[] m_chain_list;

  private Rigidbody2D m_rb;

  private Animator m_anim;

  [SerializeField]
  private float m_boss_vision_radius = 3.0f;

  [SerializeField]
  private int m_boss_healt = 9;

  private float m_boss_max_ball_range;

  [SerializeField]
  private float m_ball_min_radius = 0.5f;

  [SerializeField]
  private float m_ball_max_radius = 1.0f;


  private float m_elapsed_time;

  [SerializeField]
  private float m_stunned_time = 2.0f;

  private BOSS_STATE m_state = BOSS_STATE.K_IDLE;

  [SerializeField]
  private float m_speed = 2.0f;

  private float m_attack_elapsed = 0.0f;

  [SerializeField]
  private float m_attack_duration = 2.0f;

  [SerializeField]
  private float m_charge_duration = 2.0f;

  [SerializeField]
  private int m_charge_cicles = 2;

  private bool m_ball_reverse = false;

  // Start is called before the first frame update
  void 
  Start()
  {
    m_rb =    gameObject.GetComponent<Rigidbody2D>();
    m_anim =  gameObject.GetComponent<Animator>();

    m_boss_max_ball_range = m_ball_max_radius - 0.05f;

    CatchBall();
    return;
  }

  // Update is called once per frame
  void 
  Update()
  {

    Vector2 link_pos = m_link.transform.position;
    Vector2 boss_pos = gameObject.transform.position;
       
    if((link_pos - boss_pos).magnitude > m_boss_vision_radius && m_state != BOSS_STATE.K_IDLE)
    {
      CatchBall();
      m_rb.velocity = new Vector2(0.0f, 0.0f);

      m_state = BOSS_STATE.K_IDLE;
    }

    m_anim.SetBool("moving", (m_rb.velocity.magnitude <= 0.0f));
    
    //Debug.Log(Vector2.Angle(new Vector2(1.0f, 0.0f), m_rb.velocity));
    
    //if(m_rb.velocity.y > m_rb.velocity.x)
    //
    //m_anim.SetBool("up", m_rb.velocity.y > 0);
    //m_anim.SetBool("down", m_rb.velocity.y <= 0);
    //
    //m_anim.SetBool("left", m_rb.velocity.x <= 0);
    //m_anim.SetBool("right", m_rb.velocity.x > 0);


    switch (m_state)
    {
      case BOSS_STATE.K_ATTACK:
        Update_Attack();
        break;
      case BOSS_STATE.K_IDLE:
        Update_Idle();
        break;
      case BOSS_STATE.K_FOLLOW_LINK:
        Update_Follow();
        break;
      case BOSS_STATE.K_CHARGE:
        Update_Charge();
        break;
      case BOSS_STATE.K_STUNNED:
        Update_Stunned();
        break;
      default:
        break;
    }

    return;
  }

  public void
  CatchBall()
  {
    
    int elements = m_chain_list.Length;
    for (int index = 0; index < elements; ++index)
    {     

      m_chain_list[index].SetActive(false);
    }
    
    m_ball.gameObject.SetActive(false);

    return;
  }

  void
  ThrowBall()
  {
    
    int elements = m_chain_list.Length;
    for (int index = 0; index < elements; ++index)
    {
      m_chain_list[index].SetActive(true);
    }
    
    m_ball.gameObject.SetActive(true);

    return;
  }

  void
  Update_Idle()
  {
    Vector2 link_pos = m_link.transform.position;
    Vector2 boss_pos = gameObject.transform.position;

    if ((link_pos - boss_pos).magnitude <= m_boss_vision_radius)
    {
      m_state = BOSS_STATE.K_FOLLOW_LINK;
    }

    return;
  }

  void
  Update_Stunned()
  {
    m_elapsed_time += Time.deltaTime;
    if(m_elapsed_time >= m_stunned_time)
    {
      m_state = BOSS_STATE.K_FOLLOW_LINK;
      return;
    }

    m_rb.velocity = new Vector2(0.0f, 0.0f);
    return;
  }

  void
  Update_Charge()
  {
    m_attack_elapsed += Time.deltaTime;
    float norm_time = m_attack_elapsed / m_charge_duration;

    float angle = Mathf.Lerp(0.0f, (2 * Mathf.PI) * m_charge_cicles, norm_time);

    float x = Mathf.Sin(angle) * m_ball_min_radius;
    float y = Mathf.Cos(angle) * m_ball_min_radius;

    Vector2 ball_position = new Vector2(x, y);
    Vector2 boss_position = gameObject.transform.position;

    SetChainPositions(ball_position);
    ball_position += boss_position;

    m_ball.transform.position = new Vector3
    (
      ball_position.x,
      ball_position.y,
      m_ball.transform.position.z
    );

    if (norm_time >= 1.0f)
    {
      m_ball_reverse = false;
      m_attack_elapsed = 0.0f;
      m_rb.velocity = new Vector2(0.0f, 0.0f);

      m_state = BOSS_STATE.K_ATTACK;
    }

    return;
  }

  void
  Update_Attack()
  {
    m_attack_elapsed += Time.deltaTime;
    float norm_time = m_attack_elapsed / m_attack_duration;

    float angle = Mathf.Lerp(0.0f, 2 * Mathf.PI, norm_time);

    
    if(norm_time >= 1.0f && !m_ball_reverse)
    {
      norm_time = 0.0f;
      m_attack_elapsed = 0.0f;

      m_ball_reverse = true;
    }

    float amplitud;
    if (m_ball_reverse)
    {
      amplitud = Mathf.Lerp(m_ball_max_radius, m_ball_min_radius, norm_time);
    }
    else
    {
      amplitud = Mathf.Lerp(m_ball_min_radius, m_ball_max_radius, norm_time);
    }

    float x = Mathf.Sin(angle) * amplitud;
    float y = Mathf.Cos(angle) * amplitud;

    Vector2 ball_position = new Vector2(x, y);
    Vector2 boss_position = gameObject.transform.position;

    SetChainPositions(ball_position);
    ball_position += boss_position;

    m_ball.transform.position = new Vector3
    (
      ball_position.x,
      ball_position.y,
      m_ball.transform.position.z
    );

    if (norm_time >= 1.0f)
    {
      CatchBall();
      m_state = BOSS_STATE.K_FOLLOW_LINK;
    }

    return;
  }

  void
  Update_Follow()
  {
    Vector2 m_link_pos = m_link.transform.position;
    Vector2 m_boss_pos = gameObject.transform.position;

    Vector2 direction = m_link_pos - m_boss_pos;

    if(direction.magnitude <= m_boss_max_ball_range)
    {
      ThrowBall();
      
      m_attack_elapsed = 0.0f;
      m_rb.velocity =   new Vector2(0.0f, 0.0f);

      m_state = BOSS_STATE.K_CHARGE;
      return;
    }

    direction.Normalize();    
    direction *= m_speed;

    m_rb.velocity = direction;
    return;
  }

  void
  SetChainPositions(Vector2 _vector)
  {
    float elements = m_chain_list.Length;
    float multiplier = 0.0f;

    for (int index = 0; index < elements; ++index)
    {
      multiplier = index / elements;

      Vector2 boss_position = gameObject.transform.position;
      Vector2 chain_position = boss_position + _vector * multiplier;

      m_chain_list[index].transform.position = new Vector3
        (
        chain_position.x,
        chain_position.y,
        m_chain_list[index].transform.position.z
        );
    }
  }

  public void
  SwordHit(int _damage)
  {
    m_boss_healt -= _damage;
    if (m_boss_healt <= 0)
    {
      Destroy(gameObject);
      return;
    }

    return;
  }

  public void
  Hit(int _damage)
  {
    m_boss_healt -= _damage;

    m_elapsed_time = 0.0f;
    m_state = BOSS_STATE.K_STUNNED;

    CatchBall();

    return;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.tag == "Link")
    {
      Link_Controller link_cntrl = collision.gameObject.GetComponent<Link_Controller>();
      link_cntrl.Damage(damage, gameObject.transform.position);
    }

    return;
  }
}
