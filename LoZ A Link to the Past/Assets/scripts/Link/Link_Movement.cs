﻿using System.Collections;
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

  public Vector2 m_direction = new Vector2(1.0f,0.0f);

  public Vector2 m_raw_direction;
  
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
  }

  public void
  Stop()
  {
    m_link_rigidbody.velocity = new Vector2(0.0f, 0.0f);
  }

  public void
  UpdateDisplacement(Vector2 _direction)
  {
    m_link_rigidbody.velocity = _direction * LINK_N_SPEED;

    if (_direction.magnitude != 0)
    {
      m_direction = _direction;
    }

    return;
  }

  // Controla el desplazamiento de link 
  public void
  UpdateDisplacement()
  {
    float h_value = Input.GetAxis("Horizontal");
    float v_value = Input.GetAxis("Vertical");

    Vector2 direction = new Vector2(h_value, v_value);
    direction.Normalize();

    m_link_rigidbody.velocity = direction * LINK_N_SPEED;
            
    if(direction.magnitude != 0)
    {
      m_direction = direction;
    }
    
    return;
  }

  // velocidad en el movimiento de los 4 ejes.

  Rigidbody2D m_link_rigidbody;

  // static members

  /*
   * Velocidad normal de link.
   * */
  public static float LINK_N_SPEED = 0.9f;

  /*
   * Velocidad lenta de link.
   * */
  public static float LINK_L_SPEED = 0.9f;

}
