using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{

  /************************************************************************/
  /* Public                                                               */
  /************************************************************************/

  /************************************************************************/
  /* Private                                                              */
  /************************************************************************/

  // Start is called before the first frame update
  void
  Start()
  {
    // get components

    // FSM

    m_fsm = new FSM();

    m_directions = new List<Vector2>();

    //Right
    m_directions.Add(new Vector2(1, 0));

    //Top
    m_directions.Add(new Vector2(0, 1));

    //Left
    m_directions.Add(new Vector2(-1, 0));

    //Bottom
    m_directions.Add(new Vector2(0, -1));

    m_fsm.AddState(new Enemy_Idle(gameObject, m_fsm));
    m_fsm.AddState(new Enemy_Wander(gameObject, m_fsm, m_directions, m_sword));
    m_fsm.AddState(new Enemy_Sprint(gameObject, m_fsm, m_sword));
    m_fsm.AddState(new Enemy_On_Damage(gameObject, m_fsm, m_sword));
    m_fsm.AddState(new Enemy_Dead(gameObject, m_fsm));
    m_fsm.AddState(new Enemy_Stunned(gameObject, m_fsm));

    m_fsm.SetState(ENEMY_GLOBALS.STUNNED_STATE_ID);

    return;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Block")
    {

      m_fsm.m_messages.Enqueue(new Message(Message.MESSAGE_TYPE.WALL_BLOCK_COLLISION, gameObject));
    }
    else if (collision.gameObject.tag == "Link" || collision.gameObject.tag == "Enemy")
    {
      if (collision.gameObject.tag == "Link")
      {
        collision.gameObject.GetComponent<Link_Controller>().Damage(m_damage, transform.position);
      }
      Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
    }
    else if (collision.gameObject.tag == "Sword")
    {
      m_health -= 2;
      if (m_health <= 0)
      {
        m_fsm.SetState(ENEMY_GLOBALS.NORMAL_DEAD_STATE_ID);
      }
      else
      {
        m_fsm.m_messages.Enqueue(new Message(Message.MESSAGE_TYPE.SWORD_COLLISION, gameObject));

      }
    }

    else if (collision.gameObject.tag == "Boomerang")
    {
      m_fsm.SetState(ENEMY_GLOBALS.STUNNED_STATE_ID);
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {

    if (collision.gameObject.tag == "Block")
    {

      m_fsm.m_messages.Enqueue(new Message(Message.MESSAGE_TYPE.WALL_BLOCK_COLLISION, gameObject));
    }

    else if (collision.gameObject.tag == "Link" || collision.gameObject.tag == "Enemy")
    {
      if(collision.gameObject.tag == "Link")
      {
        collision.gameObject.GetComponent<Link_Controller>().Damage(m_damage, transform.position);
      }
      Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
    }

    else if(collision.gameObject.tag == "Sword")
    {
      m_health -= 2;
      if (m_health <= 0)
      {
        m_fsm.SetState(ENEMY_GLOBALS.NORMAL_DEAD_STATE_ID);
      }
      else
      {
        m_fsm.m_messages.Enqueue(new Message(Message.MESSAGE_TYPE.SWORD_COLLISION, gameObject));

      }
    }
    else if (collision.gameObject.tag == "Boomerang")
    {
      m_fsm.SetState(ENEMY_GLOBALS.STUNNED_STATE_ID);
    }
  }

  // Update is called once per frame
  void
  Update()
  {
    if(m_fsm.getActiveStateID() == ENEMY_GLOBALS.DAMAGED_STATE_ID)
    {

    }
    else if(m_fsm.getActiveStateID() == ENEMY_GLOBALS.SPRINT_STATE_ID)
    {

    }
    else if(m_fsm.getActiveStateID() == ENEMY_GLOBALS.IDLE_STATE_ID)
    {
      m_fsm.SetState(ENEMY_GLOBALS.WANDER_STATE_ID);
    }

    m_fsm.Update();
  }

  private FSM m_fsm;

  private List<Vector2> m_directions;

  [SerializeField]
  private bool m_sword = false;

  [SerializeField]
  private int m_health = 0;

  [SerializeField]
  private int m_damage = 0;
}
