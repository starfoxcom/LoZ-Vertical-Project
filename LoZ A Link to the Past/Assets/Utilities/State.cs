﻿public abstract class State
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

  //////////////////////////////////////////////////////////////////////////
  // Private Properties                                                   //
  //////////////////////////////////////////////////////////////////////////  

  protected int m_id;

}