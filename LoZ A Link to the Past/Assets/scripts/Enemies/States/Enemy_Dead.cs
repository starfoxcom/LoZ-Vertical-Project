using System.Collections.Generic;
using UnityEngine;

public class Enemy_Dead : State
{

  public Enemy_Dead(GameObject _gameObject, FSM _fsm)
  {
    m_id = ENEMY_GLOBALS.NORMAL_DEAD_STATE_ID;

    Init(_gameObject, _fsm);

    m_maxStandBy = 60;

    m_rigidBody = m_gameObject.GetComponent<Rigidbody2D>();

    m_collision = m_gameObject.GetComponent<Collider2D>();

    m_renderer = m_gameObject.GetComponent<SpriteRenderer>();

    m_animator = m_gameObject.GetComponentsInChildren<Animator>();

    m_colors = new List<Color>();

    m_colors.Add(Color.blue);
    m_colors.Add(Color.magenta);
    m_colors.Add(Color.cyan);
    m_colors.Add(Color.yellow);
    m_colors.Add(Color.black);
    m_colors.Add(Color.red);
    m_colors.Add(Color.gray);
    m_colors.Add(Color.green);
  }

  public override void
  OnExit()
  {

  }

  public override void
  OnPrepare()
  {
    m_gameObject.GetComponent<Collider2D>().isTrigger = false;
    m_rigidBody.isKinematic = false;

    m_standBy = m_colorIndex = 0;
  }

  public override void
    Update()
  {
    if (m_colorIndex < m_colors.Count)
    {
      m_renderer.color = m_colors[m_colorIndex];
    }
    else
    {
      m_colorIndex = 0;
    }

    if (m_fsm.m_messages.Count != 0)
    {
      if (onCollisionWith(Message.MESSAGE_TYPE.WALL_BLOCK_COLLISION))
      {
        stepBack();
        stopMovement();
      }
    }

    if (m_standBy == 0)
    {
      GameObject link = GameObject.FindGameObjectWithTag("Link");
      Vector3 direction = m_gameObject.transform.position - link.transform.position;
      direction.Normalize();
      m_rigidBody.velocity = direction * 1.5f;
    }
    if (m_standBy == m_maxStandBy / 2)
    {
      m_animator[1].SetBool("Dead", true);
      stopMovement();
    }
    if( m_standBy >= m_maxStandBy)
    {
      m_gameObject.SetActive(false);
    }
    ++m_colorIndex;
    ++m_standBy;
  }

  void stopMovement()
  {
    m_rigidBody.velocity = Vector2.zero;
  }

  bool onCollisionWith(Message.MESSAGE_TYPE _type)
  {
    if (m_fsm.m_messages.Peek().m_type == _type)
    {

      m_fsm.m_messages.Dequeue();
      return true;
    }
    return false;
  }

  void stepBack()
  {
    ContactPoint2D[] contacts = new ContactPoint2D[2];
    m_collision.GetContacts(contacts);

    m_gameObject.transform.position +=
        new Vector3(contacts[0].normal.x * .05f, contacts[0].normal.y * .05f);
  }

  int m_standBy, m_maxStandBy, m_colorIndex, m_deadStandBy;

  Rigidbody2D m_rigidBody;

  Collider2D m_collision;

  List<Color> m_colors;

  SpriteRenderer m_renderer;

  Animator[] m_animator;
}
