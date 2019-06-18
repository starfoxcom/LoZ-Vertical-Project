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

    //Right
    m_directions.Add(new Vector2(1, 0));

    //Top
    m_directions.Add(new Vector2(0, 1));

    //Left
    m_directions.Add(new Vector2(-1, 0));

    //Bottom
    m_directions.Add(new Vector2(0, -1));

    m_fsm.AddState(new Enemy_Wander(gameObject, m_fsm, m_directions));

    m_fsm.SetState(ENEMY_GLOBALS.WANDER_STATE_ID);

    return;
  }

  // Update is called once per frame
  void
  Update()
  {
  }

  private FSM m_fsm;

  private List<Vector2> m_directions;

  private int m_directionIndex;
}
