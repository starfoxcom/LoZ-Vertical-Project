using UnityEngine;

public class CamTransition_State
  : State
{

  /************************************************************************/
  /* PUBLIC                                                               */
  /************************************************************************/

  public CamTransition_State(GameObject _gm, FSM _fsm)
  {
    m_id = (int)CAMERA_STATE.k_TRANSTION;

    m_gameObject =  _gm;
    m_fsm =         _fsm;

    m_camera_cntrl =      m_gameObject.GetComponent<CameraController>();
    m_camera_component =  m_gameObject.GetComponent<Camera>();
    m_link_gm =           m_camera_cntrl.m_link_gm;

    m_link_transform = m_link_gm.transform;

    m_vec_defase = new Vector2
    (
    m_camera_component.orthographicSize * m_camera_component.aspect,
    m_camera_component.orthographicSize
    );

    m_link_rb = m_link_gm.GetComponent<Rigidbody2D>();

    return;
  }

  public override void
  OnExit()
  { }

  public override void
  OnPrepare()
  {
  }

  public override void
  Update()
  {

    Vector2 vec_to_target;
    Vector2 position = m_camera_cntrl.gameObject.transform.position;

    vec_to_target = m_camera_cntrl.TARGET_POSITION - position;
    float distance = vec_to_target.magnitude;

    if(distance <= 0.1f)
    {
      m_fsm.SetState((int)CAMERA_STATE.k_FOLLOW_LINK);
      return;
    }

    vec_to_target.Normalize();

    position += vec_to_target * m_cam_speed * Time.deltaTime;

    m_gameObject.transform.position = new Vector3(
      position.x,
      position.y,
      m_gameObject.transform.position.z
      );

    return;
  }

  /************************************************************************/
  /* PRIVATE                                                              */
  /************************************************************************/

  private bool m_safe_zone;

  private GameObject m_link_gm;

  private Vector2 m_vec_defase;

  private Vector2 m_direction;

  private Transform m_link_transform;

  private CameraController m_camera_cntrl;

  private Camera m_camera_component;

  private RoomManager m_room_mng;

  private Rigidbody2D m_link_rb;

  private float m_cam_speed = 1.2f;
}
