using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Link_Movement))]
[RequireComponent(typeof(Link_Data))]

public class Link_Controller : MonoBehaviour
{

  /************************************************************************/
  /* Public                                                               */
  /************************************************************************/
  
  /************************************************************************/
  /* Private                                                              */
  /************************************************************************/
  
  // Start is called before the first frame update
  void 
  Start()
  {
    // get components
    m_data = gameObject.GetComponent<Link_Data>();
    m_movement_controller = gameObject.GetComponent<Link_Movement>();

    // FSM

    m_fsm = new FSM();
    
    m_fsm.AddState(new Link_Dead());
    m_fsm.AddState(new Link_Pull());
    m_fsm.AddState(new Link_Push());
    m_fsm.AddState(new Link_Idle());

    m_fsm.SetState(LINK_GLOBALS.IDLE_STATE_ID);

    return;
  }

  // Update is called once per frame
  void 
  Update()
  {
      
  }

  private void 
  OnCollisionEnter2D(Collision2D _collision)
  {
    if(_collision.gameObject.tag == LINK_GLOBALS.CONSUMIBLE_TAG)
    {

      // get item component

      ItemBaseCollectible<int> item 
        = _collision.gameObject.GetComponent<ItemBaseCollectible<int>>();

      // actions

      ItemTypeCollectible type = item.GetItemType();
      int item_value = item.GetValue();

      switch(type)
      {
        case ItemTypeCollectible.Heart:
          m_data.AddHealth(item_value);
          break;

        case ItemTypeCollectible.Rubys:
          m_data.AddRupiah(item_value);
          break;

        case ItemTypeCollectible.SmallGreenPotion:
          m_data.AddFuel(item_value);
          break;

        default:
          break;
      }

      // delete item

      Destroy(_collision.gameObject);

    }

    return;
  }

  private FSM m_fsm;

  private Link_Data m_data;

  private Link_Movement m_movement_controller;
}
