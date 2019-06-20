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

    public Link_Data m_link;
    public ItemBomerang m_Bomerang;

    private void Start()
    {
      GameObject Temp = GameObject.FindWithTag("Link");
      m_link = Temp.GetComponent<Link_Data>();
      GameObject TempOther = GameObject.FindGameObjectWithTag("Item_Tool");
      m_Bomerang = TempOther.GetComponent<ItemBomerang>();
    }


    private void Update()
    {
      if (Input.GetButtonDown("Button_A"))
      {
        m_Bomerang.ItemAcction(new Vector2(-1, 0), m_link.transform.position);

      }
      else if (Input.GetKey(KeyCode.A))
      {

      }
      else if (Input.GetKey(KeyCode.D))
      {

      }
      else if (Input.GetKey(KeyCode.S))
      {

      }


    }


  }
}
