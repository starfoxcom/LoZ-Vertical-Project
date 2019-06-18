using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang_Controller : MonoBehaviour
{
  //////////////////////////////////////////////////////////////////////////
  // Public Methods                                                       //
  //////////////////////////////////////////////////////////////////////////
  
  public void
  Throw()
  {
    Link_Data linkData = m_link.GetComponent<Link_Data>();
    linkData.m_has_boomerang = false;

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

  public float
  getRadius()
  {
    return m_radius;
  }

  //////////////////////////////////////////////////////////////////////////
  // Public Properties                                                    //
  //////////////////////////////////////////////////////////////////////////

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
  OnCollisionEnter(Collision _collision)
  {
    if(_collision.gameObject.tag == "Link")
    {
      Catch();      
    }

    return;
  }

  //////////////////////////////////////////////////////////////////////////
  // Private Properties                                                   //
  //////////////////////////////////////////////////////////////////////////      

  GameObject m_link = null;

  Rigidbody2D m_rb = null;
  
  FSM m_fsm = null;

  float m_radius = 5.0f;

  public static int IDLE_STATE = 0;

  public static int FORWARD_STATE = 0;

  public static int BACK_STATE = 0;
}
