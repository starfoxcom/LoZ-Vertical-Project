﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// this class represent a ruby item in the game world.
/// </summary>
namespace Assets.Item_Scripts
{
  class ItemRuby : ItemBaseCollectible<int>
  {

    public AudioClip m_rup;

    private SoundManager m_snd_mng;

    //! the colors correspond to the value of the ruby's
    public enum RubyColor : sbyte
    {
      Green = 1,
      Blue = 5,
      Red = 20
    }

   public RubyColor m_rubyColor = RubyColor.Green;
    //! how much a ruby is valued at (how many ruby's link get from this ruby)
    int m_Value;

    int m_Limit = 999;


    private void Start()
    {
      GameObject room_mng = GameObject.FindGameObjectWithTag("RoomManager");
      m_snd_mng = room_mng.GetComponent<SoundManager>();

      if (m_rubyColor != RubyColor.Blue || m_rubyColor != RubyColor.Red)
      {
        m_rubyColor = RubyColor.Green;
        m_Value = 1;
      }
      else if(m_rubyColor == RubyColor.Blue)
      {
        m_Value = 5;
      }
      else if(m_rubyColor == RubyColor.Red)
      {
        m_Value = 20;
      }
      m_Limit = 999;
      // this is to identify the ruby class 
      m_ItemType = ItemTypeCollectible.Rubys;
      GetLinkData();
    }
    /// <summary>
    /// use to set the value of the ruby's denoted by there color 
    /// </summary>
    /// <param name="val"></param>
    public void setValue(int val)
    {
      if (val == 5)
      {
        m_rubyColor = RubyColor.Blue;
      }
      else if (val == 10)
      {
        m_rubyColor = RubyColor.Red;
      }
      m_Value = val;
    }

    public override int GetValue()
    {
      return m_Value;
    }


    public override bool ItemEffect(ref int RubyCount)
    {
      if (RubyCount < m_Limit)
      {
        RubyCount += m_Value;
      }
      return true;
    }// end function 

    private void OnTriggerEnter2D(Collider2D Col)
    {
      if (Col.tag == "Link" && !IsInChest)
      {
        m_link.AddRupiah(m_Value);

        m_snd_mng.PlayOneShot(m_rup);

        Destroy(gameObject);

        return;
      }
    }
  }
}
