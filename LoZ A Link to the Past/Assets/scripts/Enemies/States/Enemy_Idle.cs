using System.Collections.Generic;
using UnityEngine;

public class Enemy_Idle : State
{

  public Enemy_Idle(GameObject _gameObject, FSM _fsm)
  {
    m_id = ENEMY_GLOBALS.IDLE_STATE_ID;

    Init(_gameObject, _fsm);
  }

  public override void
  OnExit()
  {

  }

  public override void
  OnPrepare()
  {

  }

  public override void
    Update()
  {

  }
}
