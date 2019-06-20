using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.scripts.Item_Scripts.Dynamic
{
  class TorchOnState : BaseDynamicItem
  {
    // This controls how much time the torch take to turn off 
    public const float m_TorchTime = 5.0f;
    //! how much time the torch is going to be on until it stops
    float m_RemainingTime = m_TorchTime;

    public bool IsTorchON = true;

    public override bool DynamicAcction()
    {
      m_RemainingTime -= Time.deltaTime;

      if (m_RemainingTime < 0)
      {
        m_RemainingTime = m_TorchTime;
        IsTorchON = false;
        return false;
      }
      return true;
    }

    //! this is used to know when to change state.
    public bool CheckTorch()
    {
      return IsTorchON;
    }

  }
}
