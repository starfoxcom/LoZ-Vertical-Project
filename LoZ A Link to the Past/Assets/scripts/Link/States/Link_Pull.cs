using UnityEngine;

public class Link_Pull
  : State
{

  public Link_Pull(GameObject _gameObject, FSM _fsm)
  {
    m_id = LINK_GLOBALS.PULL_STATE_ID;

    m_fsm         = _fsm;
    m_gameObject  = _gameObject;

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
