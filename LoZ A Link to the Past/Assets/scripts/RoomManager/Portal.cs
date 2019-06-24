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

  public Transform m_spawn_transform;

  public Vector2 SPAWN_POSITION
  {
    get
    {
      return m_spawn_transform.position;
    }
  }

  private void 
  Start()
  {
    m_direction 
      = m_exit_portal.gameObject.transform.position - gameObject.transform.position;
    m_direction.Normalize();

    SpriteRenderer spr_rnd = m_spawn_transform.gameObject.GetComponent<SpriteRenderer>();
    spr_rnd.enabled = false;

    return;
  }

  private void 
  OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.gameObject.tag == "Link")
    {    

      Link_Controller link_cntrl = collision.gameObject.GetComponent<Link_Controller>();
      link_cntrl.EnterPortal(this, m_exit_portal);        

      return;
    }
  }
}
