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
    }


    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Alpha1))
      {
        Spawner Span = GetComponent<Spawner>();
        Span.StartSpawn();
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
