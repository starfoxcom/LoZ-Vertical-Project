using System.Collections;
using UnityEngine;

public enum ItemTypeCollectible
{
  Unknown,
  Heart,
  SmallGreenPotion,
  Rubys,
  Key,
  MasterKey
}


public abstract class ItemBaseCollectible<T> : MonoBehaviour
{
  public ItemTypeCollectible m_ItemType { get; set; }
  // Use this for initialization
  // this a reference to a link 
  public Link_Data m_link;

  void Start()
  {
    Debug.Log("Collectible item BASE");

    GameObject Temp = GameObject.FindWithTag("Link");
    m_link = Temp.GetComponent<Link_Data>();

    m_ItemType = ItemTypeCollectible.Unknown;
  }

  public void InitItem()
  { 
    GameObject Temp = GameObject.FindWithTag("Link");
    m_link = Temp.GetComponent<Link_Data>();
  }

  public ItemTypeCollectible GetItemType()
  {
    return m_ItemType;
  }

  public abstract int GetValue();
  //! this method will increase (or possible decrease) some stat
  public abstract bool ItemEffect(ref T Stat);

}
