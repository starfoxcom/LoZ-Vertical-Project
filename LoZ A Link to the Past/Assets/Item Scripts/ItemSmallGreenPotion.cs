using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Item_Scripts
{
  class ItemSmallGreenPotion : ItemBaseCollectible<int>
  {
    //TODO: find out the actual limit later 
    int m_MagicaLimit = 10;
    private void Start()
    {
      m_ItemType = ItemTypeCollectible.SmallGreenPotion;
    }

    public override bool ItemEffect(ref int Magica)
    {

      if (Magica < m_MagicaLimit)
      {
        Magica += 1;
        Debug.Log("Here is the magica now " + Magica.ToString());
        return true;
      }
      return false;
    }// end function 

    public override int GetValue()
    {
      return 1;
    }
  }
}
