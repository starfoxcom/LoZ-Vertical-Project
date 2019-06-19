using UnityEngine;

public class Link_Idle
  : State
{

  /************************************************************************/
  /* Public                                                               */
  /************************************************************************/

  public 
  Link_Idle(GameObject _gameObject, FSM _fsm)
  {
    m_id = LINK_GLOBALS.IDLE_STATE_ID;

    m_gameObject = _gameObject;
    m_fsm = _fsm;

    //////////////////////////////////////////
    // Components

    m_link_cntrl =    m_gameObject.GetComponent<Link_Controller>();
    m_link_data =     m_gameObject.GetComponent<Link_Data>();
    m_link_move =     m_gameObject.GetComponent<Link_Movement>();
    m_link_animator = m_gameObject.GetComponent<Link_Animation_Controller>();

    return;
  }

  public override void
  OnExit()
  {}

  public override void
  OnPrepare()
  {
  }

  public override void
  Update()
  {
    if (Input.GetButtonDown("Button_A"))
    {
      if (m_link_data.m_has_boomerang)
      {
        m_fsm.SetState(LINK_GLOBALS.BOOMERANG_STATE_ID);
      }
    }

    return;
  }

  /************************************************************************/
  /* Private                                                              */
  /************************************************************************/

  Link_Controller m_link_cntrl;

  Link_Data m_link_data;

  Link_Movement m_link_move;

  Link_Animation_Controller m_link_animator;
}