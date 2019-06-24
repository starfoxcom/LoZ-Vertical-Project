using System;
using System.Collections;
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
      OFF,
      FOREVER
    }
    //! represent the state thats being used.
    BaseDynamicItem m_CurrentTorchState = null;
    //! to keep track of the state of the torch 
    public TorchState m_CurrentState;

    private void Start()
    {
      // assign the initial torch state.
      if (m_CurrentState != TorchState.FOREVER)
      {
        switch (m_CurrentState)
        {
          case (TorchState.OFF):
            m_CurrentTorchState = gameObject.AddComponent<TorchOnState>();
            break;
          case (TorchState.ON):
            m_CurrentTorchState = gameObject.AddComponent<TorchOffState>();
            break;
          default:
            m_CurrentState = TorchState.OFF;
            m_CurrentTorchState = gameObject.AddComponent<TorchOffState>();
            break;
        }
      }
      else
      {
        m_CurrentTorchState = gameObject.AddComponent<TorchForeverState>();
      }
    }
    /// <summary>
    /// USED THIS TO DICTATE WHAT TYPE OF 
    /// TORCH TO USE IN THE SCENE.
    /// </summary>
    /// <returns></returns>
    public TorchState GetTorchState()
    {
      return m_CurrentState;
    }

    void ChangeState()
    {
      switch (m_CurrentState)
      {
        case (TorchState.OFF):
          m_CurrentTorchState = null;
          m_CurrentTorchState = this.gameObject.AddComponent<TorchOnState>();
          m_CurrentState = TorchState.ON;
          break;
        case (TorchState.ON):
          m_CurrentTorchState = null;
          m_CurrentTorchState = this.gameObject.AddComponent<TorchOffState>();
          m_CurrentState = TorchState.OFF;
          break;
      }

    }

    private void Update()
    {
      if (!m_CurrentTorchState.DynamicAcction())
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
            m_CurrentTorchState = this.gameObject.AddComponent<TorchOnState>();
            m_CurrentState = TorchState.ON;
            break;
        }
      }
    }
   
  }
}
