using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Item_Scripts
{
  class ItemKey : ItemBaseCollectible<int>
  {

    private SoundManager m_snd_mng;

    public AudioClip m_key_snd;

    private void Start()
    {
      GameObject room_mng = GameObject.FindGameObjectWithTag("RoomManager");
      m_snd_mng = room_mng.GetComponent<SoundManager>();

      m_ItemType = ItemTypeCollectible.Key;
      GetLinkData();
    }

    public override int GetValue()
    {
      return 1;
    }

    public override bool ItemEffect(ref int Stat)
    {
      Stat += 1;
      return true;
    }

    private void OnTriggerEnter2D(Collider2D Col)
    {

      if(Col.tag == "Link" && !IsInChest)
      {
        m_link.AddKey(1);

        m_snd_mng.PlayOneShot(m_key_snd);

        Destroy(gameObject);
        
      }

    }

  }

}
