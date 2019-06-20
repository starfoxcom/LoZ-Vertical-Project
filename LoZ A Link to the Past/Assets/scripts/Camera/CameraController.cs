﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  /************************************************************************/
  /* PUBLIC                                                               */
  /************************************************************************/

  public GameObject m_link_gm;

  public Camera m_camera;

  /************************************************************************/
  /* PRIVATE                                                              */
  /************************************************************************/
    
  void 
  Start()
  {
    m_fsm = new FSM();

    m_fsm.AddState(new FollowLink_State(gameObject, m_fsm));

    m_fsm.SetState((int)CAMERA_STATE.k_FOLLOW_LINK);

    //////////////////////////////////////////
    // Tech Aspect

    m_camera = gameObject.GetComponent<Camera>();

    m_camera.aspect = 1.1428f;

    return;
  }
    
  void 
  Update()
  {
    m_fsm.Update();
  }

  private FSM m_fsm;
}
