﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.scripts.Item_Scripts.Spawner_s
{
  class Spawner : MonoBehaviour
  {
    const int m_MinItems = 3;

    public SpawnableItems m_SelectedSpawn = SpawnableItems.RANDOM;
    ///<summary>
    ///Here Goes the prefabs of Item that the games spawns from 
    ///the Pots, when destroyed
    ///</summary>
    public GameObject[] m_SpanwableItems;

    private void Start()
    {
      Debug.AssertFormat(m_SpanwableItems.Length >= m_MinItems, "Error not enoughs Prefabs need at least {0}", m_MinItems);
    }// end function 

    void RandomSpawn()
    {
      // because the function returns a float 
      int Truncation = UnityEngine.Random.Range(-1, 2);

      if (Truncation >= 0)
      {
        Instantiate(m_SpanwableItems[Truncation], transform.position, Quaternion.identity);
      }
    }

    public void StartSpawn()
    {
      Spawn((int)m_SelectedSpawn);
    }

    /*      // collectible items 
    public const int Unknown = -1;
    public const int Heart = 0;
    public const int SmallGreenPotion = 1;
    public const int Rubys = 2;
    public const int Key = 3;
    public const int MasterKey = 4;
  /*  // Player usable Items 
    public const int Boomerang = 5;
    public const int Lamp = 6;*/

    /// <summary>
    /// Takes care of making instances of all the items of the Game 
    /// </summary>
    /// <param name="Index"></param>
    void Spawn(int Index)
    {
      switch (Index)
      {
        case AllSpawnbleItem.Collec_Unknown:
          RandomSpawn();
          break;

        case AllSpawnbleItem.Collec_Heart:
          //   make one of the items spawn in the same place the pot was.
          Instantiate(m_SpanwableItems[AllSpawnbleItem.Collec_Heart], transform.position, Quaternion.identity);
          break;// end case 
        case AllSpawnbleItem.Collec_SmallGreenPotion:
          Instantiate(m_SpanwableItems[AllSpawnbleItem.Collec_SmallGreenPotion], transform.position, Quaternion.identity);
          break;// end case 
        case AllSpawnbleItem.Collec_Ruby:
          Instantiate(m_SpanwableItems[AllSpawnbleItem.Collec_Ruby], transform.position, Quaternion.identity);
          break;// end case 
        case AllSpawnbleItem.Collec_Key:
          // make one of the items spawn in the same place the pot was.
          Instantiate(m_SpanwableItems[AllSpawnbleItem.Collec_Key], transform.position, Quaternion.identity);
          break;// end case 
        case AllSpawnbleItem.Collec_MasterKey:
          Instantiate(m_SpanwableItems[AllSpawnbleItem.Collec_MasterKey], transform.position, Quaternion.identity);
          break;// end case 
                //****************End of Collectible items ***********//

        //*************************TODO************************// 
        case AllSpawnbleItem.PlayerUse_Boomerang:
          // Instantiate(m_SpanwableItems[AllSpawnbleItem.PlayerUse_Boomerang], transform.position, Quaternion.identity);
          break;// end case 
        case AllSpawnbleItem.PlayerUse_Lamp:
          // Instantiate(m_SpanwableItems[AllSpawnbleItem.PlayerUse_Lamp], transform.position, Quaternion.identity);
          break;// end case 
          //*****************End of usable Items ****************//
      }
    }// end function  
  }
}
