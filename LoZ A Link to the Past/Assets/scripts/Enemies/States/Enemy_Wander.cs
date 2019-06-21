using System.Collections.Generic;
using UnityEngine;

public class Enemy_Wander : State
{

  public Enemy_Wander(GameObject _gameObject, FSM _fsm, List<Vector2> _directions, bool _sword = false)
  {
    m_id = ENEMY_GLOBALS.WANDER_STATE_ID;

    Init(_gameObject, _fsm);

    m_directions = _directions;

    m_rigidBody = m_gameObject.GetComponent<Rigidbody2D>();

    m_maxStandBy = 50;

    m_maxTime = 150;

    m_sword = _sword;

  }

  public override void
  OnExit()
  {

  }

  public override void
  OnPrepare()
  {
    m_timer = m_standBy = 0;

    setNewDirection(m_sword);
  }

  public override void
  Update()
  {

    if(m_fsm.m_messages.Count != 0)
    {
      if(onCollisionWith(Message.MESSAGE_TYPE.WALL_BLOCK_COLLISION))
      {

        if (m_sword)
        {

          if (m_directionIndex == 0)
          {

            m_directionIndex = 2;
          }
          else if (m_directionIndex == 1)
          {

            m_directionIndex = 3;
          }
          else if (m_directionIndex == 2)
          {

            m_directionIndex = 0;
          }
          else
          {

            m_directionIndex = 1;
          }

         m_rigidBody.velocity = m_directions[m_directionIndex] * .25f;

          GameObject link = GameObject.FindGameObjectWithTag("Link");

          Vector3 distance = link.transform.position - m_gameObject.transform.position;

          if (distance.magnitude <= 1)
          {
            m_fsm.SetState(ENEMY_GLOBALS.SPRINT_STATE_ID);
          }

          m_fsm.m_messages.Clear();

          return;
        }

        stopDirection();

        m_timer = m_maxTime;

        return;
      }
    }

    if (m_timer >= m_maxTime)
    {

      if (m_standBy <= m_maxStandBy)
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

  void setNewDirection(bool _sword)
  {

    int temp = 0;

    if (m_sword)
    {

      temp = Random.Range(0, m_directions.Count);

      int inverse = 0;

      if(m_directionIndex == 0)
      {

        inverse = 2;
      }
      else if(m_directionIndex == 1)
      {

        inverse = 3;
      }
      else if(m_directionIndex == 2)
      {

        inverse = 0;
      }
      else
      {

        inverse = 1;
      }

      while(temp == inverse)
      {
        temp = Random.Range(0, m_directions.Count);
      }

      m_directionIndex = temp;
    }
    else
    {

      temp = Random.Range(0, 2);

      if (m_directionIndex != 0 && m_directionIndex != m_directions.Count - 1)
      {

        m_directionIndex = (temp == 0) ? ++m_directionIndex : --m_directionIndex;
      }
      else
      {

        if (m_directionIndex == 0)
        {

          m_directionIndex = (temp == 0) ? ++m_directionIndex : m_directions.Count - 1;
        }
        else if (m_directionIndex == m_directions.Count - 1)
        {

          m_directionIndex = (temp == 0) ? 0 : --m_directionIndex;
        }
      }
    }

    GameObject link = GameObject.FindGameObjectWithTag("Link");

    Vector3 distance = link.transform.position - m_gameObject.transform.position;

    if(distance.magnitude <= 1)
    {
      m_fsm.SetState(ENEMY_GLOBALS.SPRINT_STATE_ID);

      if(m_sword)
      {
        return;
      }
    }

    m_rigidBody.velocity = m_directions[m_directionIndex] * .25f;




    
  }

  void stopDirection()
  {
    m_rigidBody.velocity = Vector2.zero;
  }

  int m_timer, m_maxTime, m_standBy, m_maxStandBy, m_directionIndex;

  List<Vector2> m_directions;

  bool m_sword = false;

  Rigidbody2D m_rigidBody;

}
