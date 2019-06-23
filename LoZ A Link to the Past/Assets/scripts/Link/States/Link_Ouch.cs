using UnityEngine;

public class Link_Ouch
  : State
{

  public Link_Ouch(GameObject _gameObject, FSM _fsm)
  {
    m_id = LINK_GLOBALS.OUCH_STATE_ID;

    m_fsm = _fsm;
    m_gameObject = _gameObject;

    m_link_cntrl =      m_gameObject.GetComponent<Link_Controller>();
    m_link_animation =  m_gameObject.GetComponent<Link_Animation_Controller>();
    m_link_move =       m_gameObject.GetComponent<Link_Movement>();    

    return;
  }

  public override void
  OnExit()
  {
    m_link_animation.DesactiveHit();
    m_link_cntrl.ActiveInmune();
    return;
  }

  public override void
  OnPrepare()
  {
    Vector2 enemy_position = m_link_cntrl.GetEnemeyPosition();

    m_hit_direction = m_gameObject.transform.position;
    m_hit_direction -= enemy_position;
    m_hit_direction.Normalize();
    m_link_animation.ActiveHit();

    m_trigger_time = Time.time + m_hit_time;

    return;
  }

  public override void
  Update()
  {
    m_link_move.UpdateDisplacement(m_hit_direction);

    if(Time.time >= m_trigger_time)
    {
      m_fsm.SetState(LINK_GLOBALS.IDLE_STATE_ID);
      return;
    }

    return;
  }

  private float m_hit_time = 0.4f;

  private float m_trigger_time;

  private Vector2       m_hit_direction;

  private Link_Movement m_link_move;

  private Link_Animation_Controller m_link_animation;

  private Link_Controller m_link_cntrl;
}

