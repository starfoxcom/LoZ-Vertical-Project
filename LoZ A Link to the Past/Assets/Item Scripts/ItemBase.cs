using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//! used to know which type of item the player is using 
public enum ItemType
{
  Unknown,
  Collection,//<! means the item takes affect when collected example : hearts 
  PlayerUse,//<! means the player can chose when to use the item.
}

public abstract class ItemBase : MonoBehaviour
{
  //! this is just for debugging
  public string m_ItemName { get; set; }
  //! this is used to know the type of the item 
  public ItemType m_ItemType { get; set; }

  // Start is called before the first frame update
  void Start()
  {
    m_ItemName = "Base Item class";
    Debug.Log(m_ItemName);
  }
  //! depending on the item this can represent direction OR position
  public abstract void ItemAcction(Vector2 vector);
}