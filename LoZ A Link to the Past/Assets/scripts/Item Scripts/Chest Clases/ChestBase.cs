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

  [RequireComponent(typeof(Collider2D))]

  public abstract class ChestBase<T> : MonoBehaviour
  {
    //! to know if a chest is being used 
    public bool IsChestUsed = false;

    public OpenableDir m_OpeanbleDir = OpenableDir.Down;
    /// <summary>
    /// This variable is so all chest class can became solid ofter 
    /// 
    /// </summary>
    protected Collider2D m_collider;

    // used to know where link is 
    const float ThreeFourthsPi = (0.75f * Mathf.PI);
    //
    const float OneFourthsPi = (0.25f * Mathf.PI);

    public enum ItemClass
    {
      PlayerUsable,
      Collectable
    }

    /// <summary>
    /// TO know which direction link needs to be in 
    /// For him to open the chest 
    /// </summary>
    public enum OpenableDir
    {
      Right = 0,
      Up = 1,
      Left =2 ,
      Down = 3
    }

    //! find out which angle from this knight
    private float GetAngleFromLink(Link_Data Link)
    {
      Vector2 Dir;
      Vector2 Pos = this.transform.position;
      Vector2 LinkPos =  Link.transform.position;
      Dir = (Pos - LinkPos);
      Dir.Normalize();
      float angle = Mathf.Atan2(Dir.y, Dir.x);

      Debug.Log("Angle : " + angle);
      return angle;
    }

    /// <summary>
    /// Check if link is facing the chest in the right direction to open the chest 
    /// </summary>
    /// <param name="Link"></param>
    /// <returns></returns>
    protected bool isLinkFacingChest(Link_Data Link)
    {
      float Angle = GetAngleFromLink(Link);

      // Right 
      if (Angle > ThreeFourthsPi || Angle < -ThreeFourthsPi)
      {
          if(m_OpeanbleDir == OpenableDir.Right)
        { return true; }
        return false;
      }
      // Up
      else if (Angle < -OneFourthsPi && Angle > -ThreeFourthsPi)
      {
        if(m_OpeanbleDir == OpenableDir.Up)
        { return true; }
        return false;
      }
      // left 
      else if (Angle < OneFourthsPi || Angle < -OneFourthsPi)
      {
        if (m_OpeanbleDir == OpenableDir.Left)
        { return true; }
        return false;
        
      }
      // down 
      else
      {
        if (m_OpeanbleDir == OpenableDir.Down)
        { return true; }
        return false;
      }
    }// end function 


    //****************Functions**************//
    // Start is called before the first frame update


    protected bool InitChest()
    {
      m_collider = GetComponent<Collider2D>();
      if (m_collider == null)
      {
        return false;
      }
      return true;
    }

    protected void SetChestUsed()
    {
      IsChestUsed = true;
      m_collider.isTrigger = false;
    }

    protected void SetItemInChest(ref ItemBaseCollectible<int> item)
    {
      item.IsInChest = true;
    }


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
