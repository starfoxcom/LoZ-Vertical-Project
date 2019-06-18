using UnityEngine;

public class Link_Idle
  : State
{

  public Link_Idle(GameObject _gameObject, FSM _fsm)
  {
    m_id = LINK_GLOBALS.IDLE_STATE_ID;

    m_gameObject = _gameObject;
    m_fsm = _fsm;

    return;
  }

  public override void
  OnExit()
  {}

  public override void
  OnPrepare()
  {}

  public override void
  Update()
  {}
}