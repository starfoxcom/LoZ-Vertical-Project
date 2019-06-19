﻿using System.Collections;
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
    m_fsm.AddState(new Enemy_Wander(gameObject, m_fsm, m_directions));

    m_fsm.SetState(ENEMY_GLOBALS.IDLE_STATE_ID);

    return;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Block")
    {
      m_fsm.m_messages.Enqueue(new Message(Message.MESSAGE_TYPE.WALL_BLOCK_COLLISION, gameObject));
      Debug.Log(m_fsm.m_messages.Peek().m_type);
    }
  }

  // Update is called once per frame
  void
  Update()
  {

    if(m_fsm.getActiveStateID() == ENEMY_GLOBALS.IDLE_STATE_ID)
    {
      m_fsm.SetState(ENEMY_GLOBALS.WANDER_STATE_ID);
    }

    m_fsm.Update();
  }

  private FSM m_fsm;

  private List<Vector2> m_directions;
}
