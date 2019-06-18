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
    // use this to render the fire from the lamp 
    SpriteRenderer spriteRenderer;

    public Sprite FireSprite;
    public float m_fireTime;

    private void Start()
    {
      spriteRenderer = gameObject.AddComponent< SpriteRenderer >() as SpriteRenderer;
      m_ItemName = "Lamp";
      m_ItemType = ItemType.PlayerUse;
      // this is temporay REMOVE WHEN DONE  
      UnityEngine.Vector2 Dir = new Vector2(-1, 0);
      m_fireTime = 0.05f;

      ItemAcction(Dir);

      Debug.Log("Item Lamp");
    }

    public override void ItemAcction(Vector2 Direction)
    {
      Vector3 Temp = new Vector3();
      Temp = spriteRenderer.transform.position;
      Temp.x += Direction.x;
      Temp.y += Direction.y;

      Task Stun = Task.Factory.StartNew(() =>
      {
        while (m_HitStunTime > 0.0f)
        {
          m_HitStunTime -= Time.deltaTime;
          Debug.Log("You are Stunned");
        }
        m_HitStunTime = m_HisStunAmount;
      });


      spriteRenderer.transform.position = Temp;
    
      spriteRenderer.sprite = FireSprite;

      Debug.Log("Do something");
    }
  }
}
