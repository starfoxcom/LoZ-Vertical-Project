using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This is a base class for all "Dynamic items" link interacts with,
/// in other word ones that link doesn't collect 
/// Examples : the bushes and pots
/// </summary>
public abstract class BaseDynamicItem : MonoBehaviour
{
  //! for later identifying which type of Dynamic item that's used
  public enum DynamicItemID :sbyte
  {
    ERROR = -1,
    Bush = 0,
    Pots= 1,
  }
  //********************Variables************************//
  //! this is to see if link can "destroy" the item with his sword or other means 
  protected bool isDestructible = false;
  //! used to deal with the m_sprites
  public SpriteRenderer m_Renderer;
  //! what the Dynamic item uses to interface with link 
  protected Link_Controller m_LinkController;
  //! used to identify the specific Dynamic Item being used. 
  public DynamicItemID m_ItemID = DynamicItemID.ERROR;

  //********************Methods************************//

  //! This is used to get the necessary components from link 
  protected void InitDynamicItem()
  {
    // finds Link then receives the "Link_Controller" from him 
    GameObject Temp = GameObject.FindGameObjectWithTag("Link");
    m_LinkController = Temp.GetComponent<Link_Controller>();
    m_Renderer = GetComponent<SpriteRenderer>() as SpriteRenderer;
  }
  //! so it easy to 
  public void SelfDestory()
  {
    m_Renderer.sprite = null;
    Destroy(this);
  }

  //! first check if link can do it THEN do it.
  public abstract bool DynamitcAcction();

}
