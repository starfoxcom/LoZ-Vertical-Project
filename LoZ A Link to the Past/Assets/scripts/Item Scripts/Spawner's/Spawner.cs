//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UnityEngine;

//namespace Assets.scripts.Item_Scripts.Spawner_s
//{
//  class Spawner : MonoBehaviour, ISpawnable
//  {
//    /// <summary>
//    /// Here Goes the prefabs of Item that the games spawns from 
//    /// the Pots, when destroyed
//    /// </summary>
//    public GameObject[] m_SpanwableItems;

//    public GameObject m_ObjectToSpawn;



//    private void Start()
//    {

//    }// end function 

//    /*      System.Random randomNumber = new System.Random();
//      int Index = randomNumber.Next(0, m_SpanwableItems.Length);
//      // make one of the items spawn in the same place the pot was.
//      Instantiate(m_SpanwableItems[Index], transform.position, Quaternion.identity);*/
//    public bool SpawnItem()
//    {


//      return true;
//    }// end function 

//    /*      // collectible items 
//    public const int Unknown = -1;
//    public const int Heart = 0;
//    public const int SmallGreenPotion = 1;
//    public const int Rubys = 2;
//    public const int Key = 3;
//    public const int MasterKey = 4;
//  /*  // Player usable Items 
//    public const int Boomerang = 5;
//    public const int Lamp = 6;*/
//    public void Spawn(int Index)
//    {
//      switch (Index)
//      {
//        case AllSpawnbleItem.Key:
//          System.Random randomNumber = new System.Random();
//          int Idndex = randomNumber.Next(0, m_SpanwableItems.Length);
//          // make one of the items spawn in the same place the pot was.
//          Instantiate(m_SpanwableItems[Idndex], transform.position, Quaternion.identity);

//          break;
//        case AllSpawnbleItem.Heart:
//          System.Random randomNumber = new System.Random();
//          int Idndex = randomNumber.Next(0, m_SpanwableItems.Length);
//          // make one of the items spawn in the same place the pot was.
//          Instantiate(m_SpanwableItems[Idndex], transform.position, Quaternion.identity);

//          break;
//        case AllSpawnbleItem.SmallGreenPotion:

//          break;
//        case AllSpawnbleItem.MasterKey:

//          break;

//        case AllSpawnbleItem.Rubys:
//          break;

//        case AllSpawnbleItem.Boomerang:

//          break;
//        case AllSpawnbleItem.Lamp:

//          break;
//      }

//    }
//  }// end class 
//}
//*/