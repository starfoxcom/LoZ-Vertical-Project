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

    m_camera_cntrl = m_gameObject.GetComponent<CameraController>();
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

    Vector2 direction = new Vector2();
    Vector2 position = m_gameObject.transform.position;

    if(!m_camera_cntrl.LockInsideRoom(position, ref direction))
    {
      direction.Normalize();
      position += (direction * m_cam_speed * Time.deltaTime);

      m_gameObject.transform.position = new Vector3
      (
        position.x,
        position.y,
        m_gameObject.transform.position.z
      );
    }

    return;
  }

  /************************************************************************/
  /* PRIVATE                                                              */
  /************************************************************************/  

  private float m_cam_speed = 3.0f;

  private CameraController m_camera_cntrl;
}
