using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
/// <summary>
/// This class will take care of the behavior of the regular hearts that link
/// find on his journey
/// </summary>
namespace Assets.Item_Scripts
{
  class ItemHeart : ItemBaseCollectible<int>
  {
    //TODO: find out the actual limit later 
    int m_Limit = 10;
    private void Start()
    {
      m_ItemType = ItemTypeCollectible.Heart;
    }

    public override bool ItemEffect(ref int HitPoints)
    {
      if (HitPoints < m_Limit)
      {
        HitPoints += 1;
        Debug.Log("Here is the heart Count now " + HitPoints.ToString());
        return true;
      }
      return false;
    }

    public override int GetValue()
    {
      return 1;
    }
  }
}
