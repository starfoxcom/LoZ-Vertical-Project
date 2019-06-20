using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// This class creates a value of type Item and returns it when invoking "GetItem"
/// </summary>

namespace Assets.Item_Scripts
{
  public abstract class ChestBase<T> : MonoBehaviour
  {

    public bool IsChestUsed = false;

    public enum ItemClass
    {
      PlayerUsable,
      Collectable
    }
    //****************Functions**************//
    // Start is called before the first frame update

    public ItemClass GetItemClass()
    {
      return m_ItemClass;
    }
    //****************Variables**************//
    protected T m_Item;

    public ItemClass m_ItemClass;
    //****************Abstract Method**************//
    public abstract T GetItem();
  }
}
