using UnityEngine;

public abstract class State
{
  
  //////////////////////////////////////////////////////////////////////////
  // Public Methods                                                       //
  //////////////////////////////////////////////////////////////////////////

  public abstract void OnPrepare();

  public abstract void OnExit();

  public abstract void Update();

  public int GetID()
  {
    return m_id;
  }

  public void Init(GameObject _gameObject, FSM _fsm)
  {
    m_gameObject = _gameObject;
    m_fsm = _fsm;

    return;
  }

  //////////////////////////////////////////////////////////////////////////
  // Private Properties                                                   //
  //////////////////////////////////////////////////////////////////////////  

  protected int m_id;

  protected GameObject m_gameObject = null;

  protected FSM m_fsm = null;

}