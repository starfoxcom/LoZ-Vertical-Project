using System.Collections;
using UnityEngine;

public abstract class ItemBaseCollectible<T> : MonoBehaviour
{

  // Use this for initialization
  void Start()
  {
    Debug.Log("Collectible item BASE");
  }
  //! this method will increase (or possible decrease) some stat
  public abstract bool ItemEffect(ref T Stat);
}
