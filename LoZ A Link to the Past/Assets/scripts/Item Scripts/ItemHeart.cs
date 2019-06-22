using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
/// <summary>
/// This class will take care of the behavior of the regular hearts that link
/// find on his journey
/// </summary>
namespace Assets.Item_Scripts
{
  public class ItemHeart : ItemBaseCollectible<int>
  {

    private SoundManager m_snd_mng;

    public AudioClip m_heart_snd;

    //TODO: find out the actual limit later 
    int m_Limit = 10;
    int m_Value = 1;

    private void Start()
    {
      GameObject room_mng = GameObject.FindGameObjectWithTag("RoomManager");
      m_snd_mng = room_mng.GetComponent<SoundManager>();

      m_ItemType = ItemTypeCollectible.Heart;
      GetLinkData();

    }

    public override bool ItemEffect(ref int HitPoints)
    {
      if (HitPoints < m_Limit)
      {
        HitPoints += m_Value;
        Debug.Log("Here is the heart Count now " + HitPoints.ToString());
        return true;
      }
      return false;
    }

    public override int GetValue()
    {
      return m_Value;
    }

    private void OnTriggerEnter2D(Collider2D Col)
    {
      if (Col.tag == "Link" && !IsInChest)
      {
        m_link.AddHealth(m_Value);

        m_snd_mng.PlayOneShot(m_heart_snd);

        Destroy(gameObject);
      }
    }
  }
}
