using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{

  /************************************************************************/
  /* Public                                                               */
  /************************************************************************/

  /************************************************************************/
  /* Private                                                              */
  /************************************************************************/

  // Start is called before the first frame update
  void
  Start()
  {
    // get components

    // FSM

    m_fsm = new FSM();

    m_fsm.AddState(new Enemy_Wander());

    m_fsm.SetState(ENEMY_GLOBALS.WANDER_STATE_ID);

    return;
  }

  // Update is called once per frame
  void
  Update()
  {

  }

  private FSM m_fsm;
}
