using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link_Animation_Controller : MonoBehaviour
{
  private Link_Movement m_link_move;

  private Rigidbody2D m_rb;

  private Animator m_animator;

  private bool m_vertical_preference = false;

  
  // Start is called before the first frame update
  void Start()
  {
    m_link_move = gameObject.GetComponent<Link_Movement>();
    m_rb =        gameObject.GetComponent<Rigidbody2D>();
    m_animator =  gameObject.GetComponent<Animator>();

    return;
  }

  // Update is called once per frame
  void Update()
  {
    Vector2 m_direction = m_link_move.m_direction;
    Vector2 m_velocity  = m_rb.velocity;

    float speed = m_velocity.magnitude;
       
    m_animator.SetFloat("speed", speed);

    m_animator.SetBool("idle", (speed < 0.1) );

    if(Mathf.Abs(m_direction.x) == 1.0f)
    {
      m_vertical_preference = false;
    }
    else if(Mathf.Abs(m_direction.y) == 1.0f)
    {
      m_vertical_preference = true;
    }

    if(m_vertical_preference)
    {
      m_animator.SetBool("right", (m_direction.x == 1));

      m_animator.SetBool("left", (m_direction.x == -1));

      m_animator.SetBool("up", (m_direction.y > 0.0));

      m_animator.SetBool("down", (m_direction.y < -0.0));
    }
    else
    {
      m_animator.SetBool("right", (m_direction.x > 0.0));

      m_animator.SetBool("left", (m_direction.x < -0.0));

      m_animator.SetBool("up", (m_direction.y == 1.0f));

      m_animator.SetBool("down", (m_direction.y == -1.0f));
    }
  }
}
