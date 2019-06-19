using System;
using System.Collections;
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
        case (ItemTypeCollectible.Unknown):
          // no existe Item Unknown selectionar otro porfa. 
          throw new NotImplementedException();
          break;
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

    private void OnTriggerEnter2D(Collider2D Col)
    {
      Link_Data Link;
      GameObject Temp = GameObject.FindWithTag("Link");
      Link = Temp.GetComponent<Link_Data>();

      if (Col.tag == "Link")
      {
        if (IsChestUsed == false)
        {

          switch (m_ItemType)
          {
            case (ItemTypeCollectible.Rubys):
              Link.AddRupiah(m_Item.GetValue());
              break;
            case (ItemTypeCollectible.Key):
              Link.AddKey(m_Item.GetValue());
              break;
            case (ItemTypeCollectible.MasterKey):
              Link.AddMasterKey(m_Item.GetValue());
              break;
          }

          IsChestUsed = true;
        }
      }// end function

    }// end class 
  }
}
