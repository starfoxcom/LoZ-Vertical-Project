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
  setRoomPoints(Vector2 _vec_1, Vector2 _vec_2)
  {
    m_vec_1 = _vec_1;
    m_vec_2 = _vec_2;

    return;
  }

  public void
  EnterPortal(Vector2 _direction)
  {
    Vector2 position = gameObject.transform.position;
    m_target_position =  position + (_direction * 2 * m_vec_defase.x);

    m_fsm.SetState((int)CAMERA_STATE.k_TRANSTION);
    return;
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

  void 
  Start()
  {
    m_fsm = new FSM();

    m_fsm.AddState(new FollowLink_State(gameObject, m_fsm));
    m_fsm.AddState(new CamTransition_State(gameObject, m_fsm));

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
