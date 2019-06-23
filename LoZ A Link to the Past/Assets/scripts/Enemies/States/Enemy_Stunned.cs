using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stunned : State
{

  public Enemy_Stunned(GameObject _gameObject, FSM _fsm)
  {
    m_id = ENEMY_GLOBALS.STUNNED_STATE_ID;

    Init(_gameObject, _fsm);

    m_maxStandBy = 600;

    m_rigidBody = m_gameObject.GetComponent<Rigidbody2D>();

    m_collision = m_gameObject.GetComponent<Collider2D>();

    m_renderer = m_gameObject.GetComponent<SpriteRenderer>();

    foreach (var sound in m_gameObject.GetComponents<AudioSource>())
    {
      if (sound.clip.name == "LTTP_Enemy_Hit")
      {
        m_sound = sound;
      }
    }

    m_shake = 0;

    m_colors = new List<Color>();

    m_colors.Add(Color.cyan);
    m_colors.Add(Color.yellow);
    m_colors.Add(Color.gray);

  }

  public override void
  OnExit()
  {

    m_gameObject.GetComponent<Collider2D>().isTrigger = true;
    m_rigidBody.isKinematic = true;
    stopMovement();
    m_renderer.color = Color.white;
  }

  public override void
  OnPrepare()
  {
    m_gameObject.GetComponent<Collider2D>().isTrigger = false;
    m_rigidBody.isKinematic = false;

    m_standBy = m_colorIndex = 0;
    m_sound.Play();
  }

  public override void
    Update()
  {
    if (m_colorIndex < m_colors.Count)
    {
      if (m_standBy < m_maxStandBy * .05f)
      {
        m_renderer.color = m_colors[m_colorIndex];
      }
      else
      {
        m_renderer.color = Color.white;
      }
    }
    else
    {

      if (m_standBy < m_maxStandBy * .05f)
      {
        m_colorIndex = 0;
      }
      else
      {
        m_renderer.color = Color.white;

      }
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
    if(m_standBy >= m_maxStandBy * .05f)
    {
      stopMovement();
      if (m_standBy >= m_maxStandBy * .75f)
      {
        shake();
        if (m_standBy >= m_maxStandBy)
        {
          m_fsm.SetState(ENEMY_GLOBALS.IDLE_STATE_ID);
        }
      }
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

  void shake()
  {
    if (m_shake == 0)
    {
      m_gameObject.transform.position += new Vector3(1, 0, 0) * -1 * .02f;
      ++m_shake;
    }
    else if(m_shake == 1)
    {
      m_gameObject.transform.position += new Vector3(1, 0, 0) * .02f;
      --m_shake;
    }
  }

  int m_standBy, m_maxStandBy, m_colorIndex, m_shake;

  Rigidbody2D m_rigidBody;

  Collider2D m_collision;

  List<Color> m_colors;

  SpriteRenderer m_renderer;

  AudioSource m_sound;
}
