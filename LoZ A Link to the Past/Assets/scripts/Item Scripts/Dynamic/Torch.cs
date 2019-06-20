using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.scripts.Item_Scripts.Dynamic
{
  class Torch : MonoBehaviour
  {
    //! represent the possible state for the torch 
    public enum TorchState
    {
      UNKNOWN,//unknown
      ON,
      OFF
    }
    //! represent the state thats being used.
    BaseDynamicItem m_CurrentTorchState = null;
    //! to keep track of the state of the torch 
    TorchState m_CurrentState = TorchState.UNKNOWN;

    Torch()
    {
      if(m_CurrentTorchState == null)
      {
        m_CurrentTorchState = new TorchOffState();
        m_CurrentState = TorchState.OFF;
      }
    }

    void ChangeState()
    {
      switch (m_CurrentState)
      {
        case (TorchState.OFF):
          m_CurrentTorchState = null;
          m_CurrentTorchState = new TorchOnState();
          m_CurrentState = TorchState.ON;
          break;
        case (TorchState.ON):
          m_CurrentTorchState = null;
          m_CurrentTorchState = new TorchOffState();
          m_CurrentState = TorchState.OFF;
          break;
      }

    }

    private void Update()
    {
      if(!m_CurrentTorchState.DynamicAcction())
      {
        ChangeState();
      }
  
    }



    private void OnTriggerEnter2D(Collider2D Col)
    {
      if (Col.tag == "Link")
      {
        switch (m_CurrentState)
        {
          case (TorchState.OFF):
            m_CurrentTorchState = null;
            m_CurrentTorchState = new TorchOnState();
            m_CurrentState = TorchState.ON;
            break;
          case (TorchState.ON):
            m_CurrentTorchState = null;
            m_CurrentTorchState = new TorchOffState();
            m_CurrentState = TorchState.OFF;
            break;
        }
      }
    }


  }
}
