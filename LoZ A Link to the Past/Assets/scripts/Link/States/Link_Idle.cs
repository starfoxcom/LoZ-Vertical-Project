using UnityEngine;

public class Link_Idle
  : State
{

  /************************************************************************/
  /* Public                                                               */
  /************************************************************************/

  public 
  Link_Idle(GameObject _gameObject, FSM _fsm)
  {
    m_id = LINK_GLOBALS.IDLE_STATE_ID;

    m_gameObject = _gameObject;
    m_fsm = _fsm;

    //////////////////////////////////////////
    // Components

    m_link_cntrl =    m_gameObject.GetComponent<Link_Controller>();
    m_link_data =     m_gameObject.GetComponent<Link_Data>();
    m_link_move =     m_gameObject.GetComponent<Link_Movement>();
    m_link_animator = m_gameObject.GetComponent<Link_Animation_Controller>();

    return;
  }

  public override void
  OnExit()
  {}

  public override void
  OnPrepare()
  {
  }

  public override void
  Update()
  {
    if (Input.GetButtonDown("Button_A"))
    {
      switch(m_link_data.m_active_item)
      {
        case LINK_TOOLS.k_BOOMERANG:

          if (m_link_data.m_has_boomerang)
          {
            m_fsm.SetState(LINK_GLOBALS.BOOMERANG_STATE_ID);
          }

          break;

        case LINK_TOOLS.k_LAMP:
          ThrowFireFlame();
          break;

        case LINK_TOOLS.k_EMPTY:
          break;
      }
    }

    return;
  }

  /************************************************************************/
  /* Private                                                              */
  /************************************************************************/

  Link_Controller m_link_cntrl;

  Link_Data m_link_data;

  Link_Movement m_link_move;

  Link_Animation_Controller m_link_animator;

  float m_fire_spawn_mag = 0.6f;

  private void
  ThrowFireFlame()
  {
    if(m_link_data.ConsumeFuel())
    {
      GameObject lamp_fire = m_link_data.GetLampFire();

      LampFire_Controller lamp_cntrl 
        = lamp_fire.GetComponent<LampFire_Controller>();

      lamp_cntrl.ActiveLamp();

      Vector2 dir = m_link_move.m_direction;
      dir *= m_fire_spawn_mag;

      Vector2 position = m_gameObject.transform.position;
      position += dir;

      lamp_cntrl.Init(position);
    }
    else
    {
      // TODO: Mensaje que no tienes gas.
    }
  }
}