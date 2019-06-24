using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Item_Scripts
{
  class ItemSmallGreenPotion : ItemBaseCollectible<int>
  {

    private SoundManager m_snd_mng;

    public AudioClip m_posicion;

    //TODO: find out the actual limit later 
    int m_MagicaLimit = 10;
    int m_Value = 4;

    private void Start()
    {
      GameObject room_mng = GameObject.FindGameObjectWithTag("RoomManager");
      m_snd_mng = room_mng.GetComponent<SoundManager>();

      m_ItemType = ItemTypeCollectible.SmallGreenPotion;
      GetLinkData();
    }

    public override bool ItemEffect(ref int Magica)
    {

      if (Magica < m_MagicaLimit)
      {
        Magica += m_Value;
        //Debug.Log("Here is the magica now " + Magica.ToString());
        return true;
      }
      return false;
    }// end function 

    public override int GetValue()
    {
      return m_Value;
    }

    private void OnTriggerEnter2D(Collider2D Col)
    {
      if (Col.tag == "Link" && !IsInChest)
      {
        m_link.AddFuel(m_Value);

        m_snd_mng.PlayOneShot(m_posicion);

        Destroy(gameObject);
        
      }
    }
  }
}
