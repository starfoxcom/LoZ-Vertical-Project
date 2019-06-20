
using System.Collections.Generic;
using UnityEngine;

/*
 * Estructura que almacena toda la información de link. 
 * */
public class Link_Data : MonoBehaviour
{
  public bool m_has_boomerang = true;

  public LINK_TOOLS m_active_item;

  public GameObject m_lamp_fire_prefab;

  public UI_Behaviour m_ui;

  public GameObject
  GetLampFire()
  {

    GameObject lamp = null;

    foreach (GameObject fire_lamp in m_lamp_pool)
    {
      if (!fire_lamp.gameObject.activeSelf)
      {
        lamp = fire_lamp;
        break;
      }
    }

    if (lamp == null)
    {
      lamp = Instantiate
        (
        m_lamp_fire_prefab,
        gameObject.transform.position,
        Quaternion.identity
        ) as GameObject;

      Debug.Log("New fire lamp");

      m_lamp_pool.Add(lamp);
    }

    lamp.SetActive(true);



    return lamp;
  }

  public void
  AddHealth(int _health)
  {

    m_health += _health;

    if (m_health > MAX_HEALTH)
    {
      m_health = MAX_HEALTH;
    }
    else if (m_health < 0)
    {
      m_health = 0;
    }

    m_ui.ChangeHealth(ref m_health);

    return;
  }

  public void
  AddRupiah(int _rupiah)
  {
    m_num_rupiahs += _rupiah;
    if (m_num_rupiahs > 0)
    {
      m_num_rupiahs = 0;
    }

    m_ui.ChangeRupees(ref m_num_rupiahs);

    return;
  }

  public void
  AddKey(int _key)
  {
    m_num_keys += _key;

    m_ui.ChangeKeys(ref m_num_keys);

    return;
  }

  public void
  AddMasterKey(int _master_key)
  {
    m_num_master_keys += _master_key;

    return;
  }

  public void
  AddFuel(int _fuel_percent)
  {
    m_fuel_percent += m_fuel_percent;

    if (m_fuel_percent > MAX_FUEL_PERCENT)
    {
      m_fuel_percent = MAX_FUEL_PERCENT;
    }
    else if (m_fuel_percent < 0)
    {
      m_fuel_percent = 0;
    }

    m_ui.ChangeFuel(ref m_fuel_percent);

    return;
  }

  public bool
  ConsumeFuel()
  {
    if (m_fuel_percent > 0)
    {
      m_fuel_percent -= FUEL_CONSUME;
      return true;
    }

    return false;
  }

  /*
   * Número máximo de unidades de corazón que link puede tener
   * */
  static int MAX_HEALTH = 6;

  /*
   * Porcentaje máximo de gas que link debe tener.
   * */
  static int MAX_FUEL_PERCENT = 128;

  /*
   * Consumo de gas por uso
   */
  static int FUEL_CONSUME = 8;

  /************************************************************************/
  /* Private                                                              */
  /************************************************************************/

  /*
   * Vida actual de link. Ejemplo:
   * 1 -> corazón y medio
   * 2 -> corazón
   * 3 -> corazón + corazón y medio
   * 4 -> corazón + corazón   * 
   */
  private int m_health;

  /*
   * Número de llaves normales que posee link.
   * */
  private int m_num_keys;

  /*
   * Número de llaves maestras que posee link
   * */
  private int m_num_master_keys;

  /*
   * Número de rupias que tiene link
   * */
  private int m_num_rupiahs;

  /*
   * Porcentaje de gas para lampara.
   * */
  private int m_fuel_percent;

  /*
   * Número de flehcas.
   * */
  private int m_num_arrow;


  private List<GameObject> m_lamp_pool;


  /*
   * Inicialización del personaje
   * */
  private void Start()
  {

    //////////////////////////////////////////
    // Stats

    m_health =          MAX_HEALTH;
    m_num_keys =        2;
    m_num_master_keys = 0;
    m_fuel_percent =    MAX_FUEL_PERCENT;
    m_num_rupiahs =     10;
    m_num_arrow =       0;
    
    m_ui.ChangeKeys(ref m_num_keys);
    m_ui.ChangeHealth(ref m_health);        
    m_ui.ChangeFuel(ref m_fuel_percent);
    m_ui.ChangeRupees(ref m_num_rupiahs);

    //////////////////////////////////////////
    // Fire Lamp Pool

    m_lamp_pool = new List<GameObject>();
    for (int index = 0; index < 4; ++index)
    {

      GameObject lamp;

      lamp = Instantiate
       (
       m_lamp_fire_prefab,
       gameObject.transform.position,
       Quaternion.identity
       ) as GameObject;

      lamp.SetActive(false);

      m_lamp_pool.Add(lamp);
    }

    return;
  }

  private void Update()
  {
  }
}
