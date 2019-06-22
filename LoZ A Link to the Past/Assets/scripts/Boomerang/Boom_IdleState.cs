using UnityEngine;

public class Boom_IdleState
  : State
{

  private Boomerang_Controller m_boom_cntrl;

  private AudioSource m_audio;

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
    m_audio.Play();

    return;
  }

  public override void
  OnPrepare()
  {
    SpriteRenderer spr_renderer =
    m_gameObject.GetComponent<SpriteRenderer>();

    if(m_boom_cntrl == null)
    {
      m_boom_cntrl = m_gameObject.GetComponent<Boomerang_Controller>();
      m_audio = m_gameObject.GetComponent<AudioSource>();
      m_audio.clip = m_boom_cntrl.m_boomerang_snd;
    }

    m_audio.clip = m_boom_cntrl.m_boomerang_snd;
    m_audio.Stop();

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