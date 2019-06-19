using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public static bool IsLampTaken = false;
    /// <summary>
    /// For keeping track of the boomerang 
    /// </summary>
    public static bool IsBoomerangTaken = false;

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
          IsBoomerangTaken = true;
          break;
        case (ItemTypePlayerUse.Lamp):
           m_Item = new ItemLamp();
          IsLampTaken = true;
          break;
      }
    }// end function 


    public ItemTypePlayerUse GetItemType()
    {
      return m_ItemType;
    }

  }// end class  

}// names space 

