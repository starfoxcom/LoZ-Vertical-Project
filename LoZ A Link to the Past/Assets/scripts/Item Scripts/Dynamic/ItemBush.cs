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

      Spawner Temp = GetComponentInChildren<Spawner>();
      if (Temp == null)
      {
        Debug.LogAssertion("Needs a child component for this script to work");
      }
      Temp.StartSpawn();
      return true;
    }// end function 


    private void OnTriggerEnter2D(Collider2D Col)
    {
      if (Col.tag == "Link")
      {
        DynamicAcction();
        SelfDestory();
      }

    }//end function

  }// end class 
}
