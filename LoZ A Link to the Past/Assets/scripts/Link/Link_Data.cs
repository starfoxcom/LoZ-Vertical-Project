using UnityEngine;

/*
 * Estructura que almacena toda la información de link. 
 * */
public class Link_Data : MonoBehaviour
{

  /************************************************************************/
  /* Public                                                               */
  /************************************************************************/

  /*
   * Vida actual de link. Ejemplo:
   * 1 -> corazón y medio
   * 2 -> corazón
   * 3 -> corazón + corazón y medio
   * 4 -> corazón + corazón   * 
   */
  public int HEALTH
  {
    get
    {
      return m_health;
    }

    set
    {
      // añadir vida.

      m_health += value;

      // Restriginr los valores de la vida.

      if(m_health > MAX_HEALTH)
      {
        m_health = MAX_HEALTH;
      }
      else if(m_health < 0)
      {
        m_health = 0;
      }

      return;
    }
  }

  /*
   * Número de llaves normales que posee link.
   * */
  public int NORMAL_KEYS
  {
    get
    {
      return m_num_keys;
    }
    set
    {
      m_num_keys += value;
    }
  }

  /*
 * Número de llaves maestras que posee link
 * */
  public int MASTER_KEYS
  {
    get
    {
      return m_num_master_keys;
    }
    set
    {
      m_num_master_keys += value;
    }
  }

  /*
   * Número de rupias que tiene link
   * */
  public int RUPIAHS
  {
    get
    {
      return m_num_rupiahs;
    }
    set
    {
      m_num_rupiahs += value;
      if(m_num_rupiahs > 0)
      {
        m_num_rupiahs = 0;
      }
    }
  }

  public int FUEL_PERCENT
  {
    get
    {
      return m_fuel_percent;
    }
    set
    {
      // añaidr gas.

      m_fuel_percent += value;
      
      // limitar gas.

      if(m_fuel_percent > MAX_FUEL_PERCENT)
      {
        m_fuel_percent = MAX_FUEL_PERCENT;
      }
      else if(m_fuel_percent < 0)
      {
        m_fuel_percent = 0;
      }

      return;
    }
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
   * Inicialización del personaje
   * */
  private void Start()
  {
    m_health            = 6;
    m_num_keys          = 0;
    m_num_master_keys   = 0;
    m_fuel_percent      = 0;
    m_num_rupiahs       = 0;

    return;
  }

}
