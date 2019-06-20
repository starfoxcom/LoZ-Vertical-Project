using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.scripts.Item_Scripts.Dynamic
{
  // for detecting collisions
  class TorchOffState : BaseDynamicItem
  {
    public bool IsTorchOff = true;

    public override bool DynamicAcction()
    {
      if (!IsTorchOff)
      {
        IsTorchOff = false;
        return IsTorchOff;
      }

      return true;
    }

    public bool CheckTorch()
    {
      return IsTorchOff;
    }


  }
}
