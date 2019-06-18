using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayer : MonoBehaviour
{

  public int RubyStat = 1;
  public int HeartStat = 1;
  public int MagicaStat = 1;

  // Start is called before the first frame update
  void Start()
  {
    RubyStat = 1;

  }

  // Update is called once per frame
  void Update()// made commit before merge
  {

  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag == "Item_Consumible")
    {
      Debug.Log("Stat Before : " + RubyStat);
      ItemBaseCollectible<int> Item = collision.GetComponent<ItemBaseCollectible<int>>();
      Item.ItemEffect(ref RubyStat);

      if(Item.GetItemType() == ItemTypeCollectible.Rubys)
      {
        Debug.Log("Rubs are real");
      }
      if (Item.GetItemType() == ItemTypeCollectible.Heart)
      {
        Debug.Log("Heart are real");
      }
      if (Item.GetItemType() == ItemTypeCollectible.SmallGreenPotion)
      {
        Debug.Log("SmallGreenPotion are real");
      }
      Debug.Log("Stat After : " + RubyStat);
    }

  }
}
