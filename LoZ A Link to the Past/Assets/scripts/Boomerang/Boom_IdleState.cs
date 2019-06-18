using UnityEngine;

public class Boom_IdleState
  : State
{

  public Boom_IdleState()
  {
    m_id = Boomerang_Controller.IDLE_STATE;
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

    Rigidbody2D m_rb = m_gameObject.GetComponent<Rigidbody2D>();
    m_rb.velocity = new Vector2(0.0f, 0.0f);

    return;
  }

  public override void
  Update()
  {
    return;
  }
}