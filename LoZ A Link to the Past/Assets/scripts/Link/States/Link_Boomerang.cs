using UnityEngine;

public class Link_Boomerang
  : State
{

  /************************************************************************/
  /* Public                                                               */
  /************************************************************************/

  public Link_Boomerang(GameObject _gm, FSM _fsm)
  {
    m_id = LINK_GLOBALS.BOOMERANG_STATE_ID;

    m_gameObject = _gm;
    m_fsm = _fsm;

    m_link_animator =         m_gameObject.GetComponent<Animator>();
    m_link_animation_cntrl =  m_gameObject.GetComponent<Link_Animation_Controller>();
    m_link_cntrl =            m_gameObject.GetComponent<Link_Controller>();
    m_link_move =             m_gameObject.GetComponent<Link_Movement>();
    
    return;
  }

  public override void
  OnExit()
  {
    //////////////////////////////////////////
    // Animation

    m_link_animator.SetBool("boomerang", false);

    //////////////////////////////////////////
    // Resume Movement

    m_link_move.m_active_displacement = true;

    return;
  }

  public override void
  OnPrepare()
  {

    // animation variables

    m_link_animator.SetBool("boomerang", true);
    m_exit_time = Time.time + m_boomerang_anim_duration;
    m_exit_time_half = m_exit_time - (m_boomerang_anim_duration * 0.5f);

    //////////////////////////////////////////
    // Stop Movement.

    Link_Movement link_Move = m_gameObject.GetComponent<Link_Movement>();
    link_Move.m_active_displacement = false;

    return;
  }

  public override void
  Update()
  {
    if(Time.time >= m_exit_time_half)
    {
      //////////////////////////////////////////
      // Throw Boomerang

      Vector2 spawn_position = m_link_cntrl.gameObject.transform.position;

      bool up = m_link_animator.GetBool("up");
      bool down = m_link_animator.GetBool("down");
      bool left = m_link_animator.GetBool("left");
      bool right = m_link_animator.GetBool("right");

      float m_half_sprite = 0.08f;
      spawn_position += m_link_move.m_direction * m_half_sprite;

      m_link_cntrl.ThrowBoomerang(spawn_position);

      m_exit_time_half += m_boomerang_anim_duration;
    }

    if(Time.time >= m_exit_time)
    {
      m_fsm.SetState(LINK_GLOBALS.IDLE_STATE_ID);
      return;
    }

    return;
  }

  /************************************************************************/
  /* PRIVATE                                                            */
  /************************************************************************/

  Animator m_link_animator;

  Link_Animation_Controller m_link_animation_cntrl;

  Link_Controller m_link_cntrl;

  Link_Movement m_link_move;

  float m_exit_time;

  float m_exit_time_half;

  float m_boomerang_anim_duration = 0.25f;
}