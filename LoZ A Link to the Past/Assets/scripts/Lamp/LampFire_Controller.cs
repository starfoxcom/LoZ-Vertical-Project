using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampFire_Controller : MonoBehaviour
{
  /************************************************************************/
  /* PUBLIC                                                               */
  /************************************************************************/

  public float m_life_duration = 0.2f;

  public void
  ActiveLamp()
  {
    gameObject.SetActive(true);
  }

  public void
  DesactiveLamp()
  {
    gameObject.SetActive(false);
  }

  public void
  Init(Vector2 _spawn_position)
  {
    gameObject.transform.position = _spawn_position;

    m_exit_time = Time.time + m_life_duration;
    
    if(m_animator == null)
    {
      m_animator = gameObject.GetComponent<Animator>();
    }

    m_animator.Play("lamp_fire");
    
    return;
  }

  /************************************************************************/
  /* PRIVATE                                                              */
  /************************************************************************/

  private float m_exit_time;

  private Animator m_animator = null;

  private void 
  Start()
  {
    m_animator = gameObject.GetComponent<Animator>();
    return;
  }

  void 
  Update()
  {
    if(Time.time >= m_exit_time)
    {
      DesactiveLamp();
    }

    return;
  }
}
