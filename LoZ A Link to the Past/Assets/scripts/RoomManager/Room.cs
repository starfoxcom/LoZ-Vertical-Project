using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

  /************************************************************************/
  /* PUBLIC                                                               */
  /************************************************************************/

  public SpriteRenderer m_room_texture;

  public int
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

  /************************************************************************/
  /* PRIVATE                                                              */
  /************************************************************************/

  [SerializeField]
  private int m_room_id;

  Vector2 m_vector_1;
  Vector2 m_vector_2;

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

    Vector2 room_center_pos = m_room_texture.gameObject.transform.position;
    Vector2 vec_defase = new Vector2(spr_h_width, spr_h_height);

    m_vector_1 = room_center_pos - vec_defase;
    m_vector_2 = room_center_pos + vec_defase;

    return;
  }
  
}
