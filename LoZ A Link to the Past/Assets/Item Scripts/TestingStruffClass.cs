using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// this class only exist so i can tests the scripts in the crudes way possible 
/// </summary>

namespace Assets.Item_Scripts
{
  class TestingStruffClass : MonoBehaviour
  {

    int m_testingStat1 = 1;
    int m_testingStat2 = 1;//

    int[] RubyValueArry = { 1, 5, 20 };
    SByte SelectedRubyValue = 0;

    private void Update()
    {
      if (Input.GetKey(KeyCode.A))
      {
        ItemHeart itemHeart = new ItemHeart();
        Debug.Log("Heat count before " + m_testingStat1);
        itemHeart.ItemEffect(ref m_testingStat1);
      }
      else if (Input.GetKey(KeyCode.B))
      {
        ItemSmallGreenPotion smallGreenPotion = new ItemSmallGreenPotion();
        Debug.Log("Magica count before " + m_testingStat2);
        smallGreenPotion.ItemEffect(ref m_testingStat2);
      }
      else if (Input.GetKey(KeyCode.C))
      {
        ItemRuby RubyTest = new ItemRuby();
        Debug.Log("Ruby Count before " + m_testingStat2);
        RubyTest.setValue(RubyValueArry[SelectedRubyValue]);
        RubyTest.ItemEffect(ref m_testingStat2);
        Debug.Log("Ruby Count after " + m_testingStat2);
      }
      else if (Input.GetKey(KeyCode.D))
      {
        SelectedRubyValue++;
        if(SelectedRubyValue > 2)
        {
          SelectedRubyValue = 0;
        }
      }

    }


  }
}
