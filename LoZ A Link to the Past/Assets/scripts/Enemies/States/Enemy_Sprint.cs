using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sprint : State
{

  public Enemy_Sprint(GameObject _gameObject, FSM _fsm, bool _sword = false)
  {
    m_id = ENEMY_GLOBALS.SPRINT_STATE_ID;

    Init(_gameObject, _fsm);

    m_rigidBody = m_gameObject.GetComponent<Rigidbody2D>();

    m_maxStandBy = 50;

    m_maxTime = 150;

    m_sword = _sword;

    m_animator = m_gameObject.GetComponent<Animator>();
  }

  public override void OnExit()
  {

    m_gameObject.GetComponent<Collider2D>().isTrigger = true;
    stopMovement();
  }

  public override void OnPrepare()
  {

    m_timer = m_standBy = 0;

    m_direction = m_rigidBody.velocity;

    stopMovement();

    if(m_sword)
    {
      m_gameObject.GetComponent<Collider2D>().isTrigger = false;
      m_rigidBody.isKinematic = false;
    }

  }

  public override void Update()
  {

    if (m_fsm.m_messages.Count != 0)
    {
      if (onCollisionWith(Message.MESSAGE_TYPE.WALL_BLOCK_COLLISION))
      {

        if (!m_sword)
        {

          m_gameObject.transform.position +=
         new Vector3(m_rigidBody.velocity.normalized.x * -1 * .05f, m_rigidBody.velocity.normalized.y * -1 * .05f);

          m_fsm.SetState(ENEMY_GLOBALS.IDLE_STATE_ID);

          m_fsm.m_messages.Dequeue();

          return;
        }

        m_fsm.m_messages.Dequeue();

      }
    }

    Debug.DrawRay(m_gameObject.transform.position, m_direction.normalized * .1f);

    if (m_standBy >= m_maxStandBy)
    {
      startMovement();

      if (m_timer >= m_maxTime)
      {

        stopMovement();

        //TODO: If m_sword then setState to SCOUT_STATE
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

    if (m_sword)
    {
      m_direction = link.transform.position - m_gameObject.transform.position;
      m_direction.Normalize();
      m_rigidBody.velocity = m_direction * .7f;
      float angle = Mathf.Atan2(m_direction.y, m_direction.x);

      if (angle > ThreeFourthsPi || angle < -ThreeFourthsPi)
      {
        //Right
      }
      else if (angle < -OneFourthsPi && angle > -ThreeFourthsPi)
      {
        //Up
      }
      else if (angle < OneFourthsPi || angle < -OneFourthsPi)
      {
        //Left
      }
      else
      {
        //Down
      }
    }
    else
    {
      m_direction.Normalize();

      m_rigidBody.velocity = m_direction * .7f;

      m_animator.SetInteger("Direction", -1);


      m_animator.SetBool("Up", (m_direction.y == 1));

      m_animator.SetBool("Down", m_direction.y == -1);

      m_animator.SetBool("Left", m_direction.x == -1);

      m_animator.SetBool("Right", m_direction.x == 1);
    }
  }

  int m_timer, m_maxTime, m_standBy, m_maxStandBy;

  Vector3 m_direction;

  bool m_sword = false;

  Rigidbody2D m_rigidBody;

  Animator m_animator;

  const float ThreeFourthsPi = (0.75f * Mathf.PI);

  const float OneFourthsPi = (0.25f * Mathf.PI);
}
