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

    if (m_fsm.m_messages.Count != 0)
    {
      if (onCollisionWith(Message.MESSAGE_TYPE.WALL_BLOCK_COLLISION))
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

          m_gameObject.transform.position +=
          new Vector3(m_directions[m_directionIndex].x * -1 * .015f, m_directions[m_directionIndex].y * -1 * .015f);

          startMovement();

          //CApsule this in a function to select if is a simple soldier or a sword soldier
          //if (linkOnView())
          //{

          //  m_fsm.m_messages.Dequeue();

          //  return;
          //}
          m_fsm.m_messages.Dequeue();

          return;

        }

        m_gameObject.transform.position +=
          new Vector3(m_directions[m_directionIndex].x * -1 * .015f, m_directions[m_directionIndex].y * -1 * .015f);

        setNewDirection(m_sword);

        stopMovement();

        //if (linkOnView())
        //{


        //  return;
        //}

        m_standBy = 40;
        if(m_timer >= 0)
        {
          m_timer -= 5;
        }
        else
        {
          m_timer = 0;
        }

        return;
      }
    }

    Debug.DrawRay(m_gameObject.transform.position, m_directions[m_directionIndex] * .1f);

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

  void setNewDirection(bool _sword)
  {

    int temp = 0;

    if (m_sword)
    {

      temp = Random.Range(0, m_directions.Count);

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

    //if (linkOnView())
    //{

    //  return;
    //}
  }

  void stopMovement()
  {
    m_rigidBody.velocity = Vector2.zero;
  }

  void startMovement()
  {
    m_rigidBody.velocity = m_directions[m_directionIndex] * .25f;
  }

  bool linkOnView()
  {
    if (GameObject.FindGameObjectWithTag("Link"))
    {

      GameObject link = GameObject.FindGameObjectWithTag("Link");

      Vector3 distance = link.transform.position - m_gameObject.transform.position;

      if (distance.magnitude <= 1)
      {
        m_fsm.SetState(ENEMY_GLOBALS.SPRINT_STATE_ID);

        return true;
      }
    }

    return false;
  }

  int m_timer, m_maxTime, m_standBy, m_maxStandBy, m_directionIndex;

  List<Vector2> m_directions;

  bool m_sword = false;

  Rigidbody2D m_rigidBody;

}
