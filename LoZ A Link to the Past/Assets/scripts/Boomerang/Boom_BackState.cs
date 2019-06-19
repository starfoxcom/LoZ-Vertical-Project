using UnityEngine;

public class Boom_BackState 
  : State
{

  public Boom_BackState()
  {
    m_id = Boomerang_Controller.BACK_STATE;

    m_link = null;

    return;
  }

  public override void
  OnExit()
  { }

  public override void
  OnPrepare()
  {

    // get link

    Boomerang_Controller boomerang =
      m_gameObject.GetComponent<Boomerang_Controller>();

    m_link =  boomerang.getLink();
    m_speed = boomerang.m_boom_speed;

    // get link rigidbody

    m_rb = m_gameObject.GetComponent<Rigidbody2D>();

    return;
  }

  public override void
  Update()
  {
    Vector2 direction 
      = m_link.transform.position - m_gameObject.transform.position;

    direction.Normalize();

    m_rb.velocity = direction * m_speed;

    return;
  }

  GameObject m_link;

  Rigidbody2D m_rb;

  float m_speed;
}
