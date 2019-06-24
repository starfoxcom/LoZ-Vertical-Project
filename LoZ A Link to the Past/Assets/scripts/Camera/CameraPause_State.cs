using UnityEngine;

public class CameraPause_State
  : State
{

  /************************************************************************/
  /* PUBLIC                                                               */
  /************************************************************************/

  public CameraPause_State(GameObject _gm, FSM _fsm)
  {
    m_id = (int)CAMERA_STATE.k_PAUSE;

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
