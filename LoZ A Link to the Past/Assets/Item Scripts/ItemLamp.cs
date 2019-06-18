using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Item_Scripts
{
  /// <summary>
  /// all this does is spawn a sprite and collision box in the direction thats front
  /// </summary>
  public class ItemLamp : ItemBase
  {
    //*********************Variables ***********//
    // use this to render the fire from the lamp 
    SpriteRenderer spriteRenderer;

    public Sprite m_FireSprite;
    //! to know how munch time the fire sprite will remain on screen 
    public float m_fireTime;
    //! this is to reset m_fireTime;
    public float m_fireTimeAmount;
    //! to know if a sprite is on screen
    bool isOnScreen;
    //! to know if it hit something or not 
    public Collider2D m_collider;


    //*********************Functions***********//
    private void Start()
    {
      isOnScreen = false;

      m_collider = GetComponent<Collider2D>();

      spriteRenderer = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;

      m_ItemName = "Lamp";
      m_ItemType = ItemType.PlayerUse;
      // this is temporay REMOVE WHEN DONE  
      UnityEngine.Vector2 Dir = new Vector2(-10, 0);

      m_fireTime = 0.05f;
      m_fireTimeAmount = m_fireTime;

      Debug.Log("Item" + m_ItemName);
    }// end function
    /// <summary>
    /// make the sprite of the fire disappear after it invoked.
    /// </summary>
    private void Update()
    {
     
      if (isOnScreen)
      {
        m_fireTime -= Time.deltaTime;
        if(m_fireTime < 0.01)
        {
          spriteRenderer.sprite = null;
          isOnScreen = false;
          // reset the time 
          m_fireTime = m_fireTimeAmount;
        }

      }

    }// end function 

    /// <summary>
    /// this function will make the fire sprite appear
    /// </summary>
    /// <param name="Direction"></param>
    /// <param name="PlayerPosition"></param>
    /// <returns></returns>
    public override Vector2 ItemAcction(Vector2 Direction, Vector2 PlayerPosition)
    {
      Vector3 Result = new Vector3();
      // get the spites current possession 
      Result = PlayerPosition;

      Result.x += Direction.x;
      Result.y += Direction.y;

      spriteRenderer.transform.position = Result;

      spriteRenderer.sprite = m_FireSprite;

      isOnScreen = true;
      return Result;
    }// end function 

  }
}
