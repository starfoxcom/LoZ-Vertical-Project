using Assets.Item_Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.scripts.Item_Scripts.Dynamic
{

  class ItemPots : BaseDynamicItem
  {
    /// <summary>
    /// Here Goes the prefabs of Item that the games spawns from 
    /// the Pots, when destroyed
    /// </summary>
    public GameObject[] m_SpanwableItems;

    private void Start()
    {
      InitDynamicItem();
      m_ItemID = DynamicItemID.Pots;//  Dynamic
    }// end function 


    public override bool DynamicAcction()
    {
      System.Random randomNumber = new System.Random();
      int Index = randomNumber.Next(0, m_SpanwableItems.Length);
      // make one of the items spawn in the same place the pot was.
      Instantiate(m_SpanwableItems[Index], transform.position, Quaternion.identity);

      return true;
    }// end function 

  }// end class 
}
