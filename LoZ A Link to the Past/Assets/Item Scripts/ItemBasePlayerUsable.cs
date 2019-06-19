using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//! used to know which type of item the player is using 


  public enum ItemTypePlayerUse
  {
    Unknown,//<! means we forgot to assign the appropriate value. 
    Boomerang,//<! means the item takes affect when collected example : hearts 
    Lamp,//<! represents the lamp item 
  }


/// <summary>
/// This is a base class for all items the player can use 
/// </summary>
public abstract class ItemBasePlayerUsable : MonoBehaviour
{
  //! this is just for debugging
  public string m_ItemName { get; set; }
  //! this is used to know the type of the item 
  public ItemTypePlayerUse m_ItemType { get; set; }

  // Start is called before the first frame update
  void Start()
  {
    m_ItemName = "Base Item class";

    m_ItemType = ItemTypePlayerUse.Unknown;

    Debug.Log(m_ItemName);
  }

  ItemTypePlayerUse GetItemType()
  {
    return m_ItemType;
  }

  string GetItemName()
  {
    return m_ItemName;
  }

  //! depending on the item this can represent direction OR position
  public abstract Vector2 ItemAcction(Vector2 direction, Vector2 Position);
}