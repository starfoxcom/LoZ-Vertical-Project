using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sprint : State
{

  public Enemy_Sprint(GameObject _gameObject, FSM _fsm, List<Vector2> _directions, bool _sword = false)
  {
    m_id = ENEMY_GLOBALS.SPRINT_STATE_ID;

    Init(_gameObject, _fsm);

    m_rigidBody = m_gameObject.GetComponent<Rigidbody2D>();

    m_directions = _directions;

    m_maxStandBy = 50;

    m_maxTime = 150;

    m_sword = _sword;
  }

  public override void OnExit()
  {

  }

  public override void OnPrepare()
  {

    m_timer = m_standBy = 0;


  }

  public override void Update()
  {

    if (m_fsm.m_messages.Count != 0)
    {
      if (onCollisionWith(Message.MESSAGE_TYPE.WALL_BLOCK_COLLISION))
      {

        if (!m_sword)
        {
          m_fsm.SetState(ENEMY_GLOBALS.IDLE_STATE_ID);

        }

        m_fsm.m_messages.Dequeue();

        return;
      }
    }

    if (m_standBy >= m_maxStandBy)
    {
      startMovement();

      if (m_timer >= m_maxTime)
      {

        stopMovement();

        m_fsm.SetState(ENEMY_GLOBALS.IDLE_STATE_ID);

        return;
      }

      ++m_timer;
    }

    ++m_standBy;
  }

  bool onCollisionWith(Message.MESSAGE_TYPE _type)
  {
    if (m_fsm.m_messages.Peek().m_type == _type)
    {

      m_fsm.m_messages.Dequeue();
      return true;
    }

    m_fsm.m_messages.Dequeue();
    return false;
  }

  void stopMovement()
  {
    m_gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
  }

  void startMovement()
  {

    GameObject link = GameObject.FindGameObjectWithTag("Link");

    Vector3 direction;

    if (m_sword)
    {
      direction = link.transform.position - m_gameObject.transform.position;
      direction.Normalize();
      m_rigidBody.velocity = direction * .5f;
    }
    else
    {
      direction = m_rigidBody.velocity;
      direction.Normalize();
      m_rigidBody.velocity = direction * .5f;
    }
  }

  int m_timer, m_maxTime, m_standBy, m_maxStandBy, m_directionIndex;

  List<Vector2> m_directions;

  bool m_sword = false;

  Rigidbody2D m_rigidBody;
}
