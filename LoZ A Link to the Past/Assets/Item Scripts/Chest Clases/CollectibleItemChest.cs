using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
///  this class will be able 
/// </summary>
namespace Assets.Item_Scripts
{
  class CollectibleItemChest : ChestBase<ItemBaseCollectible<int>>
  {
    //! this is used to know which Collectible the chest contains 
    public ItemTypeCollectible m_ItemType;

    public override ItemBaseCollectible<int> GetItem()
    {
      return m_Item;
    }

    private void Start()
    {
      switch (m_ItemType)
      {
        case (ItemTypeCollectible.Rubys):
          m_Item = new ItemRuby();
          break;
        case (ItemTypeCollectible.Key):
          m_Item = new ItemKey();
          break;
        case (ItemTypeCollectible.MasterKey):
          m_Item = new ItemMasterKey();
          break;
      }
    }// end function 


  }
}
