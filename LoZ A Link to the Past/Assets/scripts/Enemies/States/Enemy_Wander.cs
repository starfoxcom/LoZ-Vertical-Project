﻿using System.Collections.Generic;
using UnityEngine;

public class Enemy_Wander : State
{

  public Enemy_Wander(GameObject _gameObject, FSM _fsm, List<Vector2> _directions)
  {
    m_id = ENEMY_GLOBALS.WANDER_STATE_ID;

    Init(_gameObject, _fsm);

    m_directions = _directions;
  }

  public override void
  OnExit()
  {

  }

  public override void
  OnPrepare()
  {
    m_timer = m_standBy = 0;

    setNewDirection();
  }

  public override void
  Update()
  {

    if(m_fsm.m_messages.Count != 0)
    {
      if(onCollisionWith(Message.MESSAGE_TYPE.WALL_BLOCK_COLLISION))
      {

        m_fsm.SetState(ENEMY_GLOBALS.IDLE_STATE_ID);

        m_timer = m_standBy = 0;
        return;
      }
    }

    if (m_timer >= 150)
    {

      if (m_standBy <= 50)
      {

        stopDirection();

        ++m_standBy;

        return;
      }

      m_fsm.SetState(ENEMY_GLOBALS.IDLE_STATE_ID);
    }

    ++m_timer;
  }

  bool onCollisionWith(Message.MESSAGE_TYPE _type)
  {
    if(m_fsm.m_messages.Peek().m_type == _type)
    {

      m_fsm.m_messages.Dequeue();
      return true;
    }

    m_fsm.m_messages.Dequeue();
    return false;
  }

  void setNewDirection()
  {
    int temp = m_directionIndex;

    while (m_directionIndex == temp)
    {
      temp = Random.Range(0, m_directions.Count);
    }

    m_directionIndex = temp;

    m_gameObject.GetComponent<Rigidbody2D>().velocity = m_directions[m_directionIndex];
  }

  void stopDirection()
  {
    m_gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
  }

  int m_timer, m_standBy, m_directionIndex;
  List<Vector2> m_directions;

}