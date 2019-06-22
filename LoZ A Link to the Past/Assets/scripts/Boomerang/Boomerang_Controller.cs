using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang_Controller : MonoBehaviour
{
  //////////////////////////////////////////////////////////////////////////
  // Public Methods                                                       //
  //////////////////////////////////////////////////////////////////////////

  public AudioClip m_boomerang_snd;

  public Vector2 m_spawn_position;

  public float m_boom_radius = 5.0f;

  public float m_boom_speed = 0.6f;

  public void
  Throw(Vector2 _spawn_position)
  {
    Link_Data linkData = m_link.GetComponent<Link_Data>();
    linkData.m_has_boomerang = false;

    m_spawn_position = _spawn_position;

    m_fsm.SetState(FORWARD_STATE);
    return;
  }

  public void
  Catch()
  {
    Link_Data linkData = m_link.GetComponent<Link_Data>();
    linkData.m_has_boomerang = true;

    m_fsm.SetState(IDLE_STATE);
    return;
  }

  public GameObject
  getLink()
  {
    return m_link;
  }  

  public void 
  SetLink(GameObject _link)
  {
    m_link = _link;
    return;
  }

  //////////////////////////////////////////////////////////////////////////
  // Private Methods                                                      //
  //////////////////////////////////////////////////////////////////////////
  
  // Start is called before the first frame update
  void Start()
  {

    m_fsm = new FSM();

    Boom_BackState backState = new Boom_BackState();
    backState.Init(gameObject, m_fsm);

    Boom_ForwardState forwardState = new Boom_ForwardState();
    forwardState.Init(gameObject, m_fsm);

    Boom_IdleState idleState = new Boom_IdleState();
    idleState.Init(gameObject, m_fsm);

    m_fsm.AddState(backState);
    m_fsm.AddState(forwardState);
    m_fsm.AddState(idleState);

    m_fsm.SetState(IDLE_STATE);   

    return;
  }

  // Update is called once per frame
  void Update()
  {
    m_fsm.Update();
    return;
  }

  private void 
  OnTriggerEnter2D(Collider2D _collision)
  {
    if (_collision.gameObject.tag == "Link")
    {
      if(m_fsm != null)
      {
        if (m_fsm.getActiveStateID() == BACK_STATE)
        {
          Catch();
        }
      }      
    }

    return;
  }

  //////////////////////////////////////////////////////////////////////////
  // Private Properties                                                   //
  //////////////////////////////////////////////////////////////////////////      

  GameObject m_link = null;

  Rigidbody2D m_rb = null;
  
  FSM m_fsm = null;  

  public static int IDLE_STATE = 0;

  public static int FORWARD_STATE = 1;

  public static int BACK_STATE = 2;
}
