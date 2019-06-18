using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Link_Movement : MonoBehaviour
{
  /************************************************************************/
  /* PUBLIC                                                               */
  /************************************************************************/

  // Flag: Puede link moverse?
  public bool m_active_displacement;

  public Vector2 m_direction;
  
  /************************************************************************/
  /* PRIVATE                                                              */
  /************************************************************************/

  // Start is called before the first frame update
  void 
  Start()
  {
    
    // Variable initialization

    m_active_displacement = true;

    // get components

    m_link_rigidbody = gameObject.GetComponent<Rigidbody2D>();


    m_direction = new Vector2(0.0f, 0.0f);
  }

  // Update is called once per frame
  void 
  Update()
  {

    // Movimiento en los 4 ejes. 

    if (m_active_displacement)
    {
      UpdateDisplacement();
    }  


  }

  // Controla el desplazamiento de link 
  public void
  UpdateDisplacement()
  {
    float h_value = Input.GetAxis("Horizontal");
    float v_value = Input.GetAxis("Vertical");

    m_direction = new Vector2(h_value, v_value);
    m_direction.Normalize();

    m_link_rigidbody.velocity = m_direction * LINK_N_SPEED;
    
    return;
  }

  // velocidad en el movimiento de los 4 ejes.

  Rigidbody2D m_link_rigidbody;

  // static members

  /*
   * Velocidad normal de link.
   * */
  static float LINK_N_SPEED = 5.0f;

  /*
   * Velocidad lenta de link.
   * */
  static float LINK_L_SPEED = 0.5f;

}
