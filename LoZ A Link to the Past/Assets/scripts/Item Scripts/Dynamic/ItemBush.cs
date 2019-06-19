using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.scripts.Item_Scripts.Dynamic
{
  class ItemBush : BaseDynamicItem
  {

    private void Start()
    {
      InitDynamicItem();
      m_ItemID = DynamicItemID.Bush;
    }

    //! in this instance it would be lifting the bush 
    public override bool DynamicAcction()
    {


      return true;
    }
  }
}
