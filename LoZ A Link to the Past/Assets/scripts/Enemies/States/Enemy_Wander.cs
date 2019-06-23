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

    m_sword = _sword;

    if (m_sword)
    {
      m_maxStandBy = 200;
    }
    else
    {
      m_maxStandBy = 50;

    }

    m_maxTime = 100;

    m_animator = m_gameObject.GetComponent<Animator>();

  }

  public override void
  OnExit()
  {

  }

  public override void
  OnPrepare()
  {
    m_timer = m_standBy = 0;

    if(m_sword)
    {
      scout();
    }
    else
    {
      setNewDirection(m_sword);
    }

    m_checked = false;
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

          stepBack();

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

          startMovement();

          if (linkOnView())
          {
            if (!m_sword)
            {
              startMovementNoAnim();
            }

            Debug.Log("I see link");
            m_fsm.SetState(ENEMY_GLOBALS.SPRINT_STATE_ID);

            return;
          }

          return;

        }

        stepBack();

        setNewDirection(m_sword);

        stopMovement();

        if (linkOnView())
        {
          if (!m_sword)
          {
            startMovementNoAnim();
          }
          Debug.Log("I see link");
          m_fsm.SetState(ENEMY_GLOBALS.SPRINT_STATE_ID);

          return;
        }

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

      else if(onCollisionWith(Message.MESSAGE_TYPE.SWORD_COLLISION))
      {
        stopMovement();
        m_fsm.SetState(ENEMY_GLOBALS.DAMAGED_STATE_ID);

        return;
      }
    }

    float offset = .1f;

    if(m_sword)
    {
      offset = 10;
    }
    Debug.DrawRay(m_gameObject.transform.position, m_directions[m_directionIndex] * 10);
    if (m_directionIndex == 0)
    {

      Debug.DrawRay(m_gameObject.transform.position, m_directions[m_directionIndex + 1] * offset);
      Debug.DrawRay(m_gameObject.transform.position, m_directions[m_directions.Count - 1] * offset);

    }
    else if (m_directionIndex == 1)
    {

      Debug.DrawRay(m_gameObject.transform.position, m_directions[m_directionIndex + 1] * offset);
      Debug.DrawRay(m_gameObject.transform.position, m_directions[m_directionIndex - 1] * offset);
    }
    else if (m_directionIndex == 2)
    {

      Debug.DrawRay(m_gameObject.transform.position, m_directions[m_directionIndex + 1] * offset);
      Debug.DrawRay(m_gameObject.transform.position, m_directions[m_directionIndex - 1] * offset);
    }
    else
    {


      Debug.DrawRay(m_gameObject.transform.position, m_directions[0] * offset);
      Debug.DrawRay(m_gameObject.transform.position, m_directions[m_directionIndex - 1] * offset);
    }

    if (m_standBy == m_maxStandBy * .25f || m_standBy == m_maxStandBy * .5f ||
      m_standBy == m_maxStandBy * .75f)
    {
      if (linkOnView())
      {
        if (!m_sword)
        {
          startMovementNoAnim();
        }

        m_fsm.SetState(ENEMY_GLOBALS.SPRINT_STATE_ID);

        if(m_fsm.m_messages.Count != 0)
        {
          m_fsm.m_messages.Dequeue();
        }

        return;
      }
    }


    if (m_standBy >= m_maxStandBy)
    {

      if(m_scouted)
      {
        setNewDirection(m_sword);

        m_scouted = false;
      }
      startMovement();

      if (m_timer == m_maxTime / 2)
      {
        if (linkOnView())
        {
          if (!m_sword)
          {
            startMovementNoAnim();
          }

          Debug.Log("I see link");
          m_fsm.SetState(ENEMY_GLOBALS.SPRINT_STATE_ID);

          if (m_fsm.m_messages.Count != 0)
          {
            m_fsm.m_messages.Dequeue();
          }

          return;
        }
      }

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
      if (m_sword)
      {
        m_fsm.m_messages.Clear();
      }
      else
      {
        m_fsm.m_messages.Dequeue();
      }

      return true;
    }
    return false;
  }

  void scout()
  {
    m_directionIndex = m_animator.GetInteger("Direction");

    m_animator.SetInteger("Direction", m_directionIndex);

    m_animator.SetBool("Up", false);

    m_animator.SetBool("Down", false);

    m_animator.SetBool("Left", false);

    m_animator.SetBool("Right", false);

    m_scouted = true;

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

      m_animator.SetInteger("Direction", temp);

      m_animator.SetBool("Up", false);

      m_animator.SetBool("Down", false);

      m_animator.SetBool("Left", false);

      m_animator.SetBool("Right", false);



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
  }

  void stepBack()
  {
    m_gameObject.transform.position +=
         new Vector3(m_directions[m_directionIndex].x * -1 * .05f, m_directions[m_directionIndex].y * -1 * .05f);
  }

  void stopMovement()
  {
    m_rigidBody.velocity = Vector2.zero;
  }

  void startMovement()
  {
    m_rigidBody.velocity = m_directions[m_directionIndex] * .5f;

    if(!m_sword)
    {
      m_animator.SetInteger("Direction", -1);
    }

    m_animator.SetBool("Up", (m_directionIndex == 1));

    m_animator.SetBool("Down", m_directionIndex == 3);

    m_animator.SetBool("Left", m_directionIndex == 2);

    m_animator.SetBool("Right", m_directionIndex == 0);
  }

  void startMovementNoAnim()
  {
    m_rigidBody.velocity = m_directions[m_directionIndex] * .5f;
  }

  bool linkOnView()
  {

    if (GameObject.FindGameObjectWithTag("Link"))
    {

      GameObject link = GameObject.FindGameObjectWithTag("Link");

      Vector3 position = link.transform.position;

      float left, right, forward;

      float offset = .1f;

      if (m_sword)
      {
        offset = 10;
      }

      if (m_directionIndex == 0)
      {
        forward = m_gameObject.transform.position.x + (m_directions[m_directionIndex].x * 10);
        left = m_gameObject.transform.position.y + (m_directions[m_directionIndex + 1].y * offset);
        right = m_gameObject.transform.position.y + (m_directions[m_directions.Count - 1].y * offset);

        if (position.x > m_gameObject.transform.position.x && position.x < forward
          && position.y > right && position.y < left)
        {
          return true;
        }

      }
      else if (m_directionIndex == 1)
      {


        forward = m_gameObject.transform.position.y + (m_directions[m_directionIndex].y * 10);
        left = m_gameObject.transform.position.x + (m_directions[m_directionIndex + 1].x * offset);
        right = m_gameObject.transform.position.x + (m_directions[m_directionIndex - 1].x * offset);

        if (position.y > m_gameObject.transform.position.y && position.y < forward
          && position.x < right && position.x > left)
        {
          return true;
        }
      }
      else if (m_directionIndex == 2)
      {

        
        forward = m_gameObject.transform.position.x + (m_directions[m_directionIndex].x * 10);
        left = m_gameObject.transform.position.y + (m_directions[m_directionIndex + 1].y * offset);
        right = m_gameObject.transform.position.y + (m_directions[m_directionIndex - 1].y * offset);

        if (position.x < m_gameObject.transform.position.x && position.x > forward
          && position.y < right && position.y > left)
        {
          return true;
        }
      }
      else
      {

        forward = m_gameObject.transform.position.y + (m_directions[m_directionIndex].y * 10);
        left = m_gameObject.transform.position.x + (m_directions[0].x * offset);
        right = m_gameObject.transform.position.x + (m_directions[m_directionIndex - 1].x * offset);

        if (position.y < m_gameObject.transform.position.y && position.y > forward
          && position.x > right && position.x < left)
        {
          return true;
        }
      }
    }
    return false;
  }

  int m_timer, m_maxTime, m_standBy, m_maxStandBy, m_directionIndex;

  List<Vector2> m_directions;

  bool m_sword = false;

  bool m_checked = false;

  bool m_scouted = false;

  Rigidbody2D m_rigidBody;

  Animator m_animator;

}
