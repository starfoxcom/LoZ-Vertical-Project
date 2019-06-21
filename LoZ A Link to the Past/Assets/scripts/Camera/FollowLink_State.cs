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

    Vector2 cam_to_room_1 = m_camera_cntrl.VECTOR_1 - new_pos;
    Vector2 cam_to_room_2 = m_camera_cntrl.VECTOR_2 - new_pos;

    cam_to_room_1.x = Mathf.Abs(cam_to_room_1.x);
    cam_to_room_1.y = Mathf.Abs(cam_to_room_1.y);
    cam_to_room_2.x = Mathf.Abs(cam_to_room_2.x);
    cam_to_room_2.y = Mathf.Abs(cam_to_room_2.y);

    if (cam_to_room_1.x < m_vec_defase.x)
    {
      new_pos.x += (m_vec_defase.x - cam_to_room_1.x); 
    }

    if(cam_to_room_1.y < m_vec_defase.y)
    {
      new_pos.y += (m_vec_defase.y - cam_to_room_1.y);
    }

    if (cam_to_room_2.x < m_vec_defase.x)
    {
      new_pos.x -= (m_vec_defase.x - cam_to_room_2.x);
    }

    if (cam_to_room_2.y < m_vec_defase.y)
    {
      new_pos.y -= (m_vec_defase.y - cam_to_room_2.y);
    }

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
