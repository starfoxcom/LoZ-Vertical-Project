using UnityEngine;

public class Boom_ForwardState
  : State
{

  /************************************************************************/
  /* PUBLIC                                                               */
  /************************************************************************/

  public Boom_ForwardState()
  {
    m_id = Boomerang_Controller.FORWARD_STATE;

    m_direction       = new Vector2();
    m_start_position  = new Vector3();    

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

    m_gameObject.transform.position = boomerang.m_spawn_position;

    m_radius =  boomerang.m_boom_radius;
    m_speed =   boomerang.m_boom_speed;

    // get rigidbody 2D

    m_rb = m_gameObject.GetComponent<Rigidbody2D>();

    // get direction

    GameObject link = boomerang.getLink();

    Link_Movement link_Movement;

    link_Movement = link.GetComponent<Link_Movement>();

    m_direction = link_Movement.m_direction;

    //////////////////////////////////////////
    // Spawn Position

    m_start_position = boomerang.m_spawn_position;

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

  /************************************************************************/
  /* PRIVATE                                                             */
  /************************************************************************/

  private float m_radius;

  private Rigidbody2D m_rb;

  private Vector2 m_direction;

  private Vector3 m_start_position;

  private float m_speed;
}
