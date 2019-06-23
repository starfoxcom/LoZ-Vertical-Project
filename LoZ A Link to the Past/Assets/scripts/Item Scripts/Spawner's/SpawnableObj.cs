using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.scripts.Item_Scripts.Spawner_s
{
  /// <summary>
  /// this is used to have the ability to spawn objects and more precisely 
  /// chose which one.
  /// </summary>
  [RequireComponent(typeof(GameObject))]
  public class SpawnableObj : MonoBehaviour
  {
    public GameObject m_Spawnable;
    public SpawnableItems m_SpawnableID = SpawnableItems.RANDOM;
  }
}
