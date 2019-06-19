using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
/// <summary>
///  this class will take care of deliveing to the player the typ of
/// </summary>
namespace Assets.Item_Scripts.Chest_Clases
{
  class PlayerUsableItemChest : ChestBase<ItemBasePlayerUsable>
  {
    public ItemTypePlayerUse m_ItemType;

    /// <summary>
    /// For keeping track of the Lamp 
    /// </summary>
    public static bool IsLampInChest = false;
    /// <summary>
    /// For keeping track of the boomerang 
    /// </summary>
    public static bool IsBoomerangInChest = false;

    /// <summary>
    /// this returns the type dictated by the m_ItemType Filed
    /// </summary>
    /// <returns></returns>
    public override ItemBasePlayerUsable GetItem()
    {
      return m_Item;
    }

    //***********************TODO*******************//
    // add the class map when it's made             // 
    private void Start()
    {
      switch (m_ItemType)
      {
        case (ItemTypePlayerUse.Boomerang):
          m_Item = new ItemBomerang();
          IsBoomerangInChest = true;
          break;

        case (ItemTypePlayerUse.Lamp):
          m_Item = new ItemLamp();
          IsLampInChest = true;
          break;
      }
    }// end function 


    public ItemTypePlayerUse GetItemType()
    {
      return m_ItemType;
    }


    private void OnTriggerEnter2D(Collider2D Col)
    {
      Link_Controller Link;

      GameObject Temp = GameObject.FindWithTag("Link");
      Link = Temp.GetComponent<Link_Controller>();

      if (Col.tag == "Link")
      {
        if (IsChestUsed == false)
        {

          switch (m_ItemType)
          {
            case (ItemTypePlayerUse.Boomerang):
              if (IsBoomerangInChest )
              {
                Link.GetBoomerang();
                IsBoomerangInChest = false;
              }

              break;
            case (ItemTypePlayerUse.Lamp):
              break;
          }

          IsChestUsed = true;
        }

      }// end function

    }// end class  

  }
}// names space 

