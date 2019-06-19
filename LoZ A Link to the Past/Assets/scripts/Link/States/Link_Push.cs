using UnityEngine;

public class Link_Push
  : State
{

  public Link_Push(GameObject _gameobject, FSM _fsm)
  {
    m_id = LINK_GLOBALS.PUSH_STATE_ID;

    m_gameObject = _gameobject;
    m_fsm = _fsm;

    return;
  }

  public override void
  OnExit()
  {
    throw new System.NotImplementedException();
  }

  public override void
  OnPrepare()
  {
    throw new System.NotImplementedException();
  }

  public override void
  Update()
  {
    throw new System.NotImplementedException();
  }
}