using UnityEngine;

public class Link_Transition
  : State
{
  /************************************************************************/
  /* PUBLIC                                                               */
  /************************************************************************/

  public Link_Transition(GameObject _gameobject, FSM _fsm)
  {
    m_id = LINK_GLOBALS.TRANSITION_STATE_ID;

    m_gameObject = _gameobject;
    m_fsm = _fsm;

    m_link_cntrl =    m_gameObject.GetComponent<Link_Controller>();
    m_link_rb =       m_gameObject.GetComponent<Rigidbody2D>();
    m_link_movement = m_gameObject.GetComponent<Link_Movement>();
    m_link_speed =    Link_Movement.LINK_N_SPEED;

    return;
  }

  public override void
  OnExit()
  {
    m_link_movement.m_active_displacement = true;
    m_link_cntrl.ExitPortal();
    return;
  }

  public override void
  OnPrepare()
  {
    m_link_movement.m_active_displacement = false;
    m_exit_portal = m_link_cntrl.GetExitPortal();
    return;
  }

  public override void
  Update()
  {
    Vector2 vec_to_exit;
    float distance_to_exit;

    Vector2 obj_position = m_gameObject.transform.position;
    vec_to_exit = m_exit_portal.SPAWN_POSITION - obj_position;

    distance_to_exit = vec_to_exit.magnitude;
    vec_to_exit.Normalize();

    // check if link is on distance

    if (distance_to_exit <= 0.1f)
    {      
      m_fsm.SetState(LINK_GLOBALS.IDLE_STATE_ID);
      return;
    }

    // Update Link movement.

    m_link_movement.UpdateDisplacement(vec_to_exit);
    return;
  }

  private Link_Controller m_link_cntrl;

  private Link_Movement m_link_movement;

  private Rigidbody2D m_link_rb;

  private Portal m_exit_portal;

  private float m_link_speed;
}
