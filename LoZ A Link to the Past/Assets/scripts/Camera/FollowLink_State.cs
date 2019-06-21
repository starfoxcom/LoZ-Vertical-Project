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
    m_camera_component = m_gameObject.GetComponent<Camera>();
    m_link_gm =       m_camera_cntrl.m_link_gm;

    m_link_transform = m_link_gm.transform;

    m_vec_defase = new Vector2
    (
    m_camera_component.orthographicSize * m_camera_component.aspect,
    m_camera_component.orthographicSize
    );
    
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
    Vector2 new_pos = new Vector2
    (
      m_link_gm.transform.position.x,
      m_link_gm.transform.position.y
    );

    Vector2 lock_vector = new Vector2();
    m_camera_cntrl.LockInsideRoom(new_pos, ref lock_vector);

    new_pos += lock_vector;

    m_gameObject.transform.position = new Vector3
      (
      new_pos.x,
      new_pos.y,
      m_gameObject.transform.position.z
      );

    return;
  }

  /************************************************************************/
  /* PRIVATE                                                              */
  /************************************************************************/

  private GameObject m_link_gm;

  private Vector2 m_vec_defase;

  private Transform m_link_transform;

  private CameraController m_camera_cntrl;

  private Camera m_camera_component;
}
