using UnityEngine;

public class FollowLink_State
  : State
{

  /************************************************************************/
  /* PUBLIC                                                               */
  /************************************************************************/

  public FollowLink_State(GameObject _gm, FSM _fsm)
  {
    m_id = (int)CAMERA_STATE.k_FOLLOW_LINK;

    m_gameObject = _gm;
    m_fsm = _fsm;

    m_camera_cntrl =  m_gameObject.GetComponent<CameraController>();
    m_link_gm =       m_camera_cntrl.m_link_gm;

    m_link_transform = m_link_gm.transform;
    
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
  {
    Vector3 new_pos = new Vector3
      (
      m_link_gm.transform.position.x,
      m_link_gm.transform.position.y,
      m_gameObject.transform.position.z
      );

    m_gameObject.transform.position = new_pos;
    return;
  }

  /************************************************************************/
  /* PRIVATE                                                              */
  /************************************************************************/

  private GameObject m_link_gm;

  private Transform m_link_transform;

  private CameraController m_camera_cntrl;
}
