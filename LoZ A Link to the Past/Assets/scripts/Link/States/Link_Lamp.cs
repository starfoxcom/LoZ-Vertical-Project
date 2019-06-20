using UnityEngine;

public class Link_Lamp
  : State
{

  public Link_Lamp(GameObject _gm, FSM _fsm)
  {
    m_id = LINK_GLOBALS.DEAD_STATE_ID;

    m_gameObject = _gm;
    m_fsm = _fsm;

    return;
  }

  public override void
  OnExit()
  { }

  public override void
  OnPrepare()
  { }

  public override void
  Update()
  { }
}
