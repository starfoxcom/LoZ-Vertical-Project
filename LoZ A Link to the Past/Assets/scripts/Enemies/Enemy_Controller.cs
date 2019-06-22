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
    m_fsm.AddState(new Enemy_Sprint(gameObject, m_fsm, m_directions, m_sword));

    m_fsm.SetState(ENEMY_GLOBALS.IDLE_STATE_ID);

    return;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    //float backOffset = 0;
    if (collision.gameObject.tag == "Block")
    {

      //if (m_fsm.getActiveStateID() == ENEMY_GLOBALS.SPRINT_STATE_ID)
      //{
      //  backOffset = 0.04f;
      //}
      //else
      //{
      //  backOffset = 0.035f;
      //}
      //gameObject.transform.position +=
      //  (gameObject.transform.position - collision.gameObject.transform.position) * backOffset;
      m_fsm.m_messages.Enqueue(new Message(Message.MESSAGE_TYPE.WALL_BLOCK_COLLISION, gameObject));
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {

    if (collision.gameObject.tag == "Block")
    {

      m_fsm.m_messages.Enqueue(new Message(Message.MESSAGE_TYPE.WALL_BLOCK_COLLISION, gameObject));
    }
  }

  // Update is called once per frame
  void
  Update()
  {
    if(m_fsm.getActiveStateID() == ENEMY_GLOBALS.SPRINT_STATE_ID)
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
}
