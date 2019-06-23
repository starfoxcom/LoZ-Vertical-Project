using UnityEngine;

public class Link_Attack
  : State
{

  public Link_Attack(GameObject _gm, FSM _fsm)
  {
    m_id = LINK_GLOBALS.ATTACK_STATE_ID;

    m_gameObject = _gm;
    m_fsm = _fsm;

    //////////////////////////////////////////
    // Get Components

    m_link_cntrl =    m_gameObject.GetComponent<Link_Controller>();
    m_link_anim =     m_gameObject.GetComponent<Link_Animation_Controller>();
    m_link_movement = m_gameObject.GetComponent<Link_Movement>();

    m_sword = m_link_cntrl.GetSword();
    m_sword_anim = m_sword.GetComponent<Animator>();

    m_shield = m_link_cntrl.GetShield();
    m_shield_anim = m_shield.GetComponent<Animator>();

    return;
  }

  public override void
  OnExit()
  {
    m_link_anim.fundarSword();
    return;
  }

  public override void
  OnPrepare()
  {
    m_link_movement.Stop();
    m_link_anim.SwordAttack();

    m_trigger_time = Time.time + m_attack_duration;
    
    return;
  }

  public override void
  Update()
  {
    if(Time.time > m_trigger_time)
    {
      m_fsm.SetState(LINK_GLOBALS.IDLE_STATE_ID);
    }

    /*
    if (Input.GetButtonDown("Button_B"))
    {
      m_fsm.SetState(LINK_GLOBALS.ATTACK_STATE_ID);
    }
    */
    return;
  }

  private float m_trigger_time;
  private float m_attack_duration = 0.2f;

  private GameObject m_sword;
  private Animator m_sword_anim;

  private GameObject m_shield;
  private Animator m_shield_anim;

  private Link_Controller           m_link_cntrl;
  private Link_Animation_Controller m_link_anim;
  private Link_Movement             m_link_movement;
}
