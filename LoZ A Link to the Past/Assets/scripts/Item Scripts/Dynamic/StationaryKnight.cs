using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// all this guy does is look in link general direction. 
/// </summary>
/// 

[RequireComponent(typeof(Sprite[]))]
[RequireComponent(typeof(SpriteRenderer))]

public class StationaryKnight : MonoBehaviour
{
  /// <summary>
  /// The m_sprites are expected to be organized counter clock-wise 
  /// </summary>
  SpriteRenderer m_Renderer;

  /// <summary>
  /// The Sprite Here should be of the golden knight that block link path 
  /// and looks in his general direction.
  /// </summary>
  public Sprite[] m_sprites;
  //! this will be used to determine which direction to face (and which sprite to us) 
  Vector2 m_Dir;
  //! this will keep track of link.
  Transform m_LinkPos;

  // used to know where link is 
  const float ThreeFourthsPi = (0.75f * Mathf.PI);
  //
  const float OneFourthsPi = (0.25f * Mathf.PI);


  private void Start()
  {
    //required that there be at-least 4 sprites 
    Debug.Assert(m_sprites.Length > 3);

    GameObject Temp = GameObject.FindGameObjectWithTag("Link");
    m_LinkPos = Temp.GetComponent<Link_Data>().transform;
    m_Renderer = GetComponent<SpriteRenderer>();

  }

  private void Update()
  {
    //Debug.Log(GetAngleFromLink());
    SetSprite();
  }

  //! find out which angle from this knight
  protected float GetAngleFromLink()
  {
    m_Dir = (transform.position - m_LinkPos.position);
    m_Dir = m_LinkPos.InverseTransformDirection(m_Dir);
    m_Dir.Normalize();
    float angle = Mathf.Atan2(m_Dir.y, m_Dir.x);
    return angle;
  }
  // this set the sprite depending on the direction 
  // in a COUNTER clock wise fashion Starting on the right side 
  void SetSprite()
  {
    float Angle = GetAngleFromLink();
    // Right 
    if (Angle > ThreeFourthsPi || Angle < -ThreeFourthsPi)
    {
      //Debug.Log("right side");
      m_Renderer.sprite = m_sprites[0];
    }
    // Up
    else if (Angle < -OneFourthsPi && Angle > -ThreeFourthsPi)
    {
      //Debug.Log("Font Side");
      m_Renderer.sprite = m_sprites[1];
    }
    // left 
    else if (Angle < OneFourthsPi || Angle < -OneFourthsPi)
    {
      //Debug.Log("Left Side");
      m_Renderer.sprite = m_sprites[2];
    }
    // down 
    else
    {
      m_Renderer.sprite = m_sprites[3];
    }


  }// end function
}
