using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link_Animation_Controller : MonoBehaviour
{
  private Link_Movement m_link_move;

  private Rigidbody2D m_rb;

  private Animator m_animator;

  public Animator m_sword_animator;

  public Animator m_shield_animator;

  Link_Controller m_link_cntrl;

  private bool m_vertical_preference = false;

  public void
  DesactiveHit()
  {
    m_animator.SetBool("hit", false);
    return;
  }

  public void
  ActiveHit()
  {
    m_animator.SetBool("hit", true);
    return;
  }

  public void
  ActiveInmune()
  {
    return;
  }

  public void
  DesactiveInmune()
  {
  }
  
  public void
  SwordAttack()
  {
    m_sword_animator.gameObject.SetActive(true);

    bool up =     m_animator.GetBool("up");
    bool down =   m_animator.GetBool("down");
    bool right =  m_animator.GetBool("right");
    bool left =   m_animator.GetBool("left");

    m_sword_animator.SetBool("up",up);
    m_sword_animator.SetBool("down", down);
    m_sword_animator.SetBool("right", right);
    m_sword_animator.SetBool("left", left);

    m_sword_animator.SetBool("active", true);
    m_animator.SetBool("attack", true);

    if(up)
    {
      m_animator.Play("link_sword_attack_up");
    }
    else if (down)
    {
      m_animator.Play("link_sword_attack_down");
    }
    else if(left)
    {
      m_animator.Play("link_sword_attack_left");
    }
    else if(right)
    {
      m_animator.Play("link_sword_attack_right");
    }
    

    return;
  }

  public void
  fundarSword()
  {
    m_sword_animator.SetBool("active", false);
    m_animator.SetBool("attack", false);

    m_sword_animator.gameObject.SetActive(false);    
    return;
  }

  // Start is called before the first frame update
  void Start()
  {
    m_link_move = gameObject.GetComponent<Link_Movement>();
    m_rb =        gameObject.GetComponent<Rigidbody2D>();
    m_animator =  gameObject.GetComponent<Animator>();

    m_link_cntrl = gameObject.GetComponent<Link_Controller>();    
    m_sword_animator.gameObject.SetActive(false);

    return;
  }

  // Update is called once per frame
  void Update()
  {
    Vector2 m_direction = m_link_move.m_direction;
    Vector2 m_velocity  = m_rb.velocity;

    float speed = m_velocity.magnitude;
       
    m_animator.SetFloat("speed", speed);

    m_animator.SetBool("idle", (speed < 0.1) );

    if(Mathf.Abs(m_direction.x) == 1.0f)
    {
      m_vertical_preference = false;
    }
    else if(Mathf.Abs(m_direction.y) == 1.0f)
    {
      m_vertical_preference = true;
    }

    if(m_vertical_preference)
    {
      m_animator.SetBool("right", (m_direction.x == 1));

      m_animator.SetBool("left", (m_direction.x == -1));

      m_animator.SetBool("up", (m_direction.y > 0.0));

      m_animator.SetBool("down", (m_direction.y < -0.0));
    }
    else
    {
      m_animator.SetBool("right", (m_direction.x > 0.0));

      m_animator.SetBool("left", (m_direction.x < -0.0));

      m_animator.SetBool("up", (m_direction.y == 1.0f));

      m_animator.SetBool("down", (m_direction.y == -1.0f));
    }
  }
}
