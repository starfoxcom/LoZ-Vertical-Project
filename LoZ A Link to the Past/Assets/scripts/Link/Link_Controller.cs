using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Link_Movement))]
[RequireComponent(typeof(Link_Data))]

public class Link_Controller : MonoBehaviour
{

  /************************************************************************/
  /* Public                                                               */
  /************************************************************************/
  
  /************************************************************************/
  /* Private                                                              */
  /************************************************************************/
  
  // Start is called before the first frame update
  void 
  Start()
  {
    // get components
    m_data = gameObject.GetComponent<Link_Data>();
    m_movement_controller = gameObject.GetComponent<Link_Movement>();

    return;
  }

  // Update is called once per frame
  void 
  Update()
  {
      
  }

  private Link_Data m_data;

  private Link_Movement m_movement_controller;
}
