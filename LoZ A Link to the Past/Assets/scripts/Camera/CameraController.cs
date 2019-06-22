using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  /************************************************************************/
  /* PUBLIC                                                               */
  /************************************************************************/

  public GameObject m_link_gm;

  public void 
  SetState(CAMERA_STATE _cam_state)
  {
    m_fsm.SetState((int)_cam_state);
    return;
  }

  public void
  setRoomPoints(Vector2 _vec_1, Vector2 _vec_2)
  {
    m_vec_1 = _vec_1;
    m_vec_2 = _vec_2;
    return;
  }

  public void
  SetPortals(Portal _from, Portal _to)
  {
    m_from  = _from;
    m_to    = _to;
    return;
  }

  public bool
  LockInsideRoom(Vector2 _cam_position, ref Vector2 _lock_vector)
  {
    Vector2 cam_to_room_1 = VECTOR_1 - _cam_position;
    Vector2 cam_to_room_2 = VECTOR_2 - _cam_position;

    cam_to_room_1.x = Mathf.Abs(cam_to_room_1.x);
    cam_to_room_1.y = Mathf.Abs(cam_to_room_1.y);
    cam_to_room_2.x = Mathf.Abs(cam_to_room_2.x);
    cam_to_room_2.y = Mathf.Abs(cam_to_room_2.y);

    _lock_vector.x = 0;
    _lock_vector.y = 0;

    if (cam_to_room_1.x < m_vec_defase.x)
    {
      _lock_vector.x = (m_vec_defase.x - cam_to_room_1.x);
    }
    else if (cam_to_room_2.x < m_vec_defase.x)
    {
      _lock_vector.x = -1 * (m_vec_defase.x - cam_to_room_2.x);
    }

    if (cam_to_room_1.y < m_vec_defase.y)
    {
      _lock_vector.y = (m_vec_defase.y - cam_to_room_1.y);
    }
    else if (cam_to_room_2.y < m_vec_defase.y)
    {
      _lock_vector.y = -1 * (m_vec_defase.y - cam_to_room_2.y);
    }

    return (_lock_vector.magnitude == 0);
  }

  public Vector2 TARGET_POSITION
  {
    get
    {
      return m_target_position;
    }
  }

  public Vector2 VECTOR_1
  {
    get
    {
      return m_vec_1;
    }
  }

  public Vector2 VECTOR_2
  {
    get
    {
      return m_vec_2;
    }
  }


  /************************************************************************/
  /* PRIVATE                                                              */
  /************************************************************************/

  private Camera m_camera;

  private Vector2 m_vec_1;

  private Vector2 m_vec_2;

  private Vector2 m_vec_defase;

  private Vector2 m_target_position;

  private Portal m_from;

  private Portal m_to;

  void 
  Start()
  {
    m_fsm = new FSM();

    m_fsm.AddState(new FollowLink_State(gameObject, m_fsm));
    m_fsm.AddState(new CamTransition_State(gameObject, m_fsm));
    m_fsm.AddState(new CameraPause_State(gameObject, m_fsm));

    m_fsm.SetState((int)CAMERA_STATE.k_FOLLOW_LINK);

    //////////////////////////////////////////
    // Tech Aspect

    m_camera = gameObject.GetComponent<Camera>();

    m_camera.aspect = 1.1428f;

    m_vec_defase = new Vector2
   (
   m_camera.orthographicSize * m_camera.aspect,
   m_camera.orthographicSize
   );

    return;
  }
    
  void 
  Update()
  {
    m_fsm.Update();
  }

  private FSM m_fsm;
}
