using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Item_Scripts
{
  class ItemMasterKey : ItemBaseCollectible<int>
  {
    private void Start()
    {
      m_ItemType = ItemTypeCollectible.MasterKey;
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
      if (Col.tag == "Link" && !IsInChest)
      {
        m_link.AddMasterKey(1);
        Destroy(this);
        SpriteRenderer temp = GetComponent<SpriteRenderer>();
        temp.sprite = null;
      }

    }

  }
}

