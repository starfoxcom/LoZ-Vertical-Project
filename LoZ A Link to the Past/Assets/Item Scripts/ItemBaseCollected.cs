using System.Collections;
using UnityEngine;

public enum ItemTypeCollectible
{
  Unknown,
  Heart,
  SmallGreenPotion,
  Rubys,
}


public abstract class ItemBaseCollectible<T> : MonoBehaviour
{
  public ItemTypeCollectible m_ItemType { get; set; }
  // Use this for initialization

  void Start()
  {
    Debug.Log("Collectible item BASE");

    m_ItemType = ItemTypeCollectible.Unknown;
  }

  public ItemTypeCollectible GetItemType()
  {
    return m_ItemType;
  }

  public abstract int GetValue();
  //! this method will increase (or possible decrease) some stat
  public abstract bool ItemEffect(ref T Stat);

}
