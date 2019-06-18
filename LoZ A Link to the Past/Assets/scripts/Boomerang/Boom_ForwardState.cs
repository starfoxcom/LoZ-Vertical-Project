using UnityEngine;

public class Boom_ForwardState
  : State
{

  public Boom_ForwardState()
  {
    m_id = Boomerang_Controller.FORWARD_STATE;

    m_direction       = new Vector2();
    m_start_position  = new Vector3();

    m_speed       = 6.0f;
    m_radius      = 15.0f;

    return;
  }

  public override void
  OnExit()
  { }

  public override void
  OnPrepare()
  {
    // set boomerang position;

    Boomerang_Controller boomerang =
      m_gameObject.GetComponent<Boomerang_Controller>();

    m_gameObject.transform.position = boomerang.getLink().transform.position;

    m_radius = boomerang.getRadius();

    // get rigidbody 2D

    m_rb = m_gameObject.GetComponent<Rigidbody2D>();

    // get direction

    Link_Movement link_Movement;

    link_Movement = m_gameObject.GetComponent<Link_Movement>();

    m_direction = link_Movement.m_direction;

    // get start position;

    m_start_position = m_gameObject.transform.position;

    return;
  }

  public override void
  Update()
  {
    m_rb.velocity = m_direction * m_speed;

    float distance 
      = (m_gameObject.transform.position - m_start_position).magnitude;

    if(distance >= m_radius)
    {
      m_fsm.SetState(Boomerang_Controller.BACK_STATE);
      return;
    }

    return;
  }

  private float m_radius;

  private Rigidbody2D m_rb;

  private Vector2 m_direction;

  private Vector3 m_start_position;

  private float m_speed;
}
