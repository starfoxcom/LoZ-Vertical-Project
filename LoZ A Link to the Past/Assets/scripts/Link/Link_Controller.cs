using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Link_Movement))]
[RequireComponent(typeof(Link_Data))]

public class Link_Controller : MonoBehaviour
{
  public bool m_inmune = false;

  /************************************************************************/
  /* Public                                                               */
  /************************************************************************/
  public void
  GetBoomerang()
  {
    GameObject boom = Instantiate(m_boomerang_prefab, gameObject.transform.position, Quaternion.identity) as GameObject;
    m_boomerang_cntr = boom.GetComponent<Boomerang_Controller>();

    m_boomerang_cntr.SetLink(gameObject);

    m_data.m_has_boomerang = true;

    return;
  }

  public GameObject m_boomerang_prefab;

  public void
  ThrowBoomerang(Vector2 _swapn_position)
  {
    m_boomerang_cntr.Throw(_swapn_position);        
    return;
  }

  public Portal
  GetExitPortal()
  {
    return m_to_portal;
  }

  public Portal
  GetFromPortal()
  {
    return m_from_portal;
  }

  public Vector2
  GetEnemeyPosition()
  {
    return m_enemy_transform;
  }

  public void
  Damage(int _hit_points, Vector2 _enemy_transport)
  {    
    if (m_fsm.getActiveStateID() != LINK_GLOBALS.OUCH_STATE_ID && !m_inmune)
    {
      m_fsm.SetState(LINK_GLOBALS.OUCH_STATE_ID);
      m_data.AddHealth(-_hit_points);
    }
    return;
  }

  public void
  EnterPortal(Portal _from, Portal _to)
  {   
    if(m_fsm.getActiveStateID() != (int)LINK_GLOBALS.TRANSITION_STATE_ID)
    {
      //////////////////////////////////////////
      // Set New Room

      GameObject room_mng = GameObject.FindGameObjectWithTag("RoomManager");
      room_mng.GetComponent<RoomManager>().SetActiveRoom(_from.m_exit_room);

      //////////////////////////////////////////
      // Set Camera State

      GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
      CameraController cam_cntrl = camera.GetComponent<CameraController>();

      cam_cntrl.SetPortals(_from, _to);
      cam_cntrl.SetState(CAMERA_STATE.k_TRANSTION);

      //////////////////////////////////////////
      // Set Link

      m_from_portal = _from;
      m_to_portal =   _to;

      m_fsm.SetState(LINK_GLOBALS.TRANSITION_STATE_ID);
    }
    return;
  }

  public void
  ExitPortal()
  {
    //////////////////////////////////////////
    // Set Camera State

    GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
    CameraController cam_cntrl = camera.GetComponent<CameraController>();

    cam_cntrl.SetState(CAMERA_STATE.k_FOLLOW_LINK);

    return;
  }

  public GameObject
  GetSword()
  {
    return m_sword_go;
  }

  public GameObject
  GetShield()
  {
    return m_shield_go;
  }

  public void
  ActiveInmune()
  {
    m_inmune_trigger = Time.time + 1.0f;
    m_inmune = true;
    return;
  }

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
    m_anim_control = gameObject.GetComponent<Link_Animation_Controller>();
    m_spr_render = gameObject.GetComponent<SpriteRenderer>();

    Transform sword_trans = gameObject.transform.Find("Link_Sword");
    Transform shield_trans = gameObject.transform.Find("Link_Shield");

    m_sword_go =  sword_trans.gameObject;
    m_shield_go = shield_trans.gameObject;

    // FSM

    m_fsm = new FSM();

    m_fsm.AddState(new Link_Dead(gameObject, m_fsm));
    m_fsm.AddState(new Link_Pull(gameObject, m_fsm));
    m_fsm.AddState(new Link_Push(gameObject, m_fsm));
    m_fsm.AddState(new Link_Idle(gameObject, m_fsm));
    m_fsm.AddState(new Link_Boomerang(gameObject, m_fsm));
    m_fsm.AddState(new Link_Transition(gameObject, m_fsm));
    m_fsm.AddState(new Link_Attack(gameObject, m_fsm));
    m_fsm.AddState(new Link_Ouch(gameObject, m_fsm));

    m_fsm.SetState(LINK_GLOBALS.IDLE_STATE_ID);

    GetBoomerang();

    return;
  }

  // Update is called once per frame
  void 
  Update()
  {
    m_fsm.Update();
    InputDebug();

    if(m_inmune)
    {
      float alpha = 0.5f + (Mathf.Sin(Time.time * 30f) * 0.3f + 0.15f);
      m_spr_render.color = new Color
      (
      m_spr_render.color.r,
      m_spr_render.color.g,
      m_spr_render.color.b,
      alpha
      );

      if(Time.time > m_inmune_trigger)
      {
        m_inmune = false;
        m_spr_render.color = new Color
        (
        m_spr_render.color.r,
        m_spr_render.color.g,
        m_spr_render.color.b,
        1.0f
        );
      }
    }

    return;
  }

  private void
  InputDebug()
  {
    if(Input.GetKeyDown(KeyCode.H))
    {
      Vector2 enem_pos = transform.position;
      enem_pos += new Vector2(1.0f, -1.0f);
      Damage(1, enem_pos);
    }

    if(Input.GetKeyDown(KeyCode.Alpha1))
    {
      m_data.AddRupiah(1);
    }

    if(Input.GetKeyDown(KeyCode.Alpha2))
    {
      m_data.AddKey(1);
    }

    if(Input.GetKeyDown(KeyCode.Alpha3))
    {
      m_data.AddHealth(1);
    }

    if(Input.GetKeyDown(KeyCode.Alpha4))
    {
      m_data.AddFuel(10);
    }
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

  private GameObject m_sword_go;

  private GameObject m_shield_go;

  private Vector2 m_enemy_transform;

  private SpriteRenderer m_spr_render;

  private float m_inmune_trigger;

  private Boomerang_Controller m_boomerang_cntr;

  private Link_Animation_Controller m_anim_control;

  private Portal m_to_portal;

  private Portal m_from_portal;
}
