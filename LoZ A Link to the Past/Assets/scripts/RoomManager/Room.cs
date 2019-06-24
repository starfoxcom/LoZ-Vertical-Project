using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ROOM_ID
{
  k_CENTER,
  K_WEST,
  K_EAST,
  K_NORTH_EAST,
  K_NORTH_WEST,
  K_NORT
}

public class Room : MonoBehaviour
{
  /************************************************************************/
  /* PUBLIC                                                               */
  /************************************************************************/

  public SpriteRenderer m_room_texture;

  public ROOM_ID
  getID()
  {
    return m_room_id;
  }

  public Vector2 VECTOR_1
  {
    get
    {
      return m_vector_1;
    }
  }

  public Vector2 VECTOR_2
  {
    get
    {
      return m_vector_2;
    }
  }

  public Vector2 POSITION
  {
    get
    {
      return m_position;
    }
  }

  /************************************************************************/
  /* PRIVATE                                                              */
  /************************************************************************/

  [SerializeField]
  private ROOM_ID m_room_id;

  Vector2 m_vector_1;
  Vector2 m_vector_2;
  Vector2 m_position;

  // Start is called before the first frame update
  void 
  Start()
  {
    int tex_width =   m_room_texture.sprite.texture.width;
    int tex_height =  m_room_texture.sprite.texture.height;
    float ppu =       m_room_texture.sprite.pixelsPerUnit;

    float spr_width = tex_width / ppu;
    float spr_height = tex_height / ppu;

    float spr_h_width = spr_width * 0.5f;
    float spr_h_height = spr_height * 0.5f;

    m_position = m_room_texture.gameObject.transform.position;
    Vector2 vec_defase = new Vector2(spr_h_width, spr_h_height);

    m_vector_1 = m_position - vec_defase;
    m_vector_2 = m_position + vec_defase;

    return;
  }
  
}
