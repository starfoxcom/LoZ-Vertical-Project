using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
  /************************************************************************/
  /* PUBLIC                                                               */
  /************************************************************************/

  public ROOM_ID m_exit_room;

  public Portal m_exit_portal;

  public Vector2 m_direction;

  private void Start()
  {
    m_direction 
      = m_exit_portal.gameObject.transform.position - gameObject.transform.position;
    m_direction.Normalize();
    return;
  }

  private void 
  OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.gameObject.tag == "Link")
    {

      GameObject room_mng = GameObject.FindGameObjectWithTag("RoomManager");
      room_mng.GetComponent<RoomManager>().SetActiveRoom(m_exit_room);

      Link_Controller link_cntrl = collision.gameObject.GetComponent<Link_Controller>();
      link_cntrl.EnterPortal(m_exit_portal);

      GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
      CameraController cam_cntrl = camera.GetComponent<CameraController>();
      cam_cntrl.EnterPortal(m_direction);      

      return;
    }
  }
}
