using System.Collections.Generic;

public class FSM
{
  
  //////////////////////////////////////////////////////////////////////////
  // Public Methods                                                       //
  //////////////////////////////////////////////////////////////////////////

  public FSM()
  {
    Init();
  }

  public void
  Init()
  {
    m_active_state = null;
    m_state_list = new List<State>();

    return;
  }

  public void
  Update()
  {
    m_active_state.Update();
    return;
  }

  public void
  AddState(State _state)
  {
    m_state_list.Add(_state);
    return;
  }

  public void
  SetState(int _id)
  {
    foreach(State state in m_state_list)
    {
      if(state.GetID() == _id)
      {
        if(m_active_state != null)
        {
          m_active_state.OnExit();
        }

        m_active_state = state;
        m_active_state.OnPrepare();
      }

      return;
    }

    return;
  }

  //////////////////////////////////////////////////////////////////////////
  // Private Properties                                                    //
  //////////////////////////////////////////////////////////////////////////

  List<State> m_state_list;

  State m_active_state = null;

}
