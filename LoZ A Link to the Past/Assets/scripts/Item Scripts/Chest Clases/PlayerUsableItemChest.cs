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
    public static bool IsLampInChest = true;
    /// <summary>
    /// For keeping track of the boomerang 
    /// </summary>
    public static bool IsBoomerangInChest = true;

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
      if (!InitChest())
      {
        Debug.LogError("Game object needs Collider ");
      }
    }// end function 


    public ItemTypePlayerUse GetItemType()
    {
      return m_ItemType;
    }


    private void OnTriggerEnter2D(Collider2D Col)
    {
      Link_Controller m_LinkController;
      Link_Data m_LinkData;

      GameObject Temp = GameObject.FindWithTag("Link");
      m_LinkController = Temp.GetComponent<Link_Controller>();
      m_LinkData = Temp.GetComponent<Link_Data>();

      if (Col.tag == "Link" && isLinkFacingChest(m_LinkData))
      {
        if (IsChestUsed == false)
        {

          switch (m_ItemType)
          {
            case (ItemTypePlayerUse.Boomerang):
              if (IsBoomerangInChest)
              {
                m_LinkController.GetBoomerang();
                IsBoomerangInChest = false;
              }

              break;
            case (ItemTypePlayerUse.Lamp):
              if (IsLampInChest)
              {
                m_LinkData.GetLampFire();
                IsLampInChest = false;
              }
              break;
            
          }

          SetChestUsed();
        }

      }// end function

    }// end class  

  }
}// end names space 

