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
    //TODO: find out the actual limit later 
    int m_MagicaLimit = 10;
    int m_Value = 1;

    private void Start()
    {
      m_ItemType = ItemTypeCollectible.SmallGreenPotion;
      GetLinkData();
    }

    public override bool ItemEffect(ref int Magica)
    {

      if (Magica < m_MagicaLimit)
      {
        Magica += m_Value;
        Debug.Log("Here is the magica now " + Magica.ToString());
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
      if (Col.tag == "Link")
      {
        m_link.AddFuel(m_Value);
        Destroy(this);
        SpriteRenderer temp = GetComponent<SpriteRenderer>();
        temp.sprite = null;
      }
    }
  }
}
