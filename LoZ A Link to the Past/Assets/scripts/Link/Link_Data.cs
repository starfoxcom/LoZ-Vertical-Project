using UnityEngine;

/*
 * Estructura que almacena toda la información de link. 
 * */
public class Link_Data : MonoBehaviour
{
  /************************************************************************/
  /* Public                                                               */
  /************************************************************************/

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
    return;
  }

  public void 
  AddRupiah(int _rupiah)
  {
    m_num_rupiahs += _rupiah;
    if (m_num_rupiahs < 0)
    {
      m_num_rupiahs = 0;
    }
    return;
  }

  public void 
  AddKey(int _key)
  {
    m_num_keys += _key;
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
    m_fuel_percent += _fuel_percent;

    if (m_fuel_percent > MAX_FUEL_PERCENT)
    {
      m_fuel_percent = MAX_FUEL_PERCENT;
    }
    else if (m_fuel_percent < 0)
    {
      m_fuel_percent = 0;
    }

    return;
  }

  /*
   * Número máximo de unidades de corazón que link puede tener
   * */
  static int MAX_HEALTH = 6;

  /*
   * Porcentaje máximo de gas que link debe tener.
   * */
  static int MAX_FUEL_PERCENT = 100;

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
    
  /*
   * Inicialización del personaje
   * */
  private void Start()
  {
    m_health            = 6;
    m_num_keys          = 0;
    m_num_master_keys   = 0;
    m_fuel_percent      = 0;
    m_num_rupiahs       = 0;
    m_num_arrow         = 0;

    return;
  }

}
