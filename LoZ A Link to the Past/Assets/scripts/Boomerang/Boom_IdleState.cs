using UnityEngine;

public class Boom_IdleState
  : State
{

  public Boom_IdleState()
  {
    m_id = Boomerang_Controller.FORWARD_STATE;
  }

  public override void
  OnExit()
  {
    SpriteRenderer spr_renderer =
    m_gameObject.GetComponent<SpriteRenderer>();

    spr_renderer.enabled = true;

    return;
  }

  public override void
  OnPrepare()
  {
    SpriteRenderer spr_renderer =
    m_gameObject.GetComponent<SpriteRenderer>();

    spr_renderer.enabled = false;

    return;
  }

  public override void
  Update()
  { }
}