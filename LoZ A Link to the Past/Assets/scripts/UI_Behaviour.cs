using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Class that changes the text of every consumable of link when 
public class UI_Behaviour : MonoBehaviour
{

    public Image m_Key; //text where its supposed to be the key sprite, it needs to hide when link its not in a dungeon

    public Image m_Boomerang;
    public Image m_Lantern;
    //Image with the heart sprites from left to right, the sprite loaded will be changed depending of links health
    public Image m_Heart0;
    public Image m_Heart1;
    public Image m_Heart2;
         
    //Sprites of hearts
    public Sprite m_FullHeart;
    public Sprite m_HalfHeart;
    public Sprite m_EmptyHeart;
    //------------------------------------------------------------------------

    //--------------------------------------
    public Image m_MagicBar;

    public Sprite[] m_MagicBarSprites = new Sprite[17];
    //private int to help changefuel()
    private static int m_last_total; // last fuel 
    private static float current;
    private static int target;
    private static bool m_animation = false;
    private static float unit;

    private static int index;
    private static float m_trigger_time;
    private static float m_duration_time = 0.4f;




    //Hud Text where it shows the stats passed by link Data--------------------------------------------
    public Text m_ShowRupees;
    public Text m_ShowBombs;
    public Text m_ShowArrows;
    public Text m_ShowKeys;
    //--------------------------------------------------------------------------------------------


    //function that disables keys hud, only use when link is not in a dungeon
    public void HideKeys()
    {
        m_Key.gameObject.SetActive(false);
        m_ShowKeys.gameObject.SetActive(false);
    }


    //function that enables key hud, only use it when link is in a dungeon
    public void ShowKeys()
    {
        m_Key.gameObject.SetActive(true);
        m_ShowKeys.gameObject.SetActive(true);
    }

    //change rupees on HUD, ref int passed by Link Data
    public void ChangeRupees(ref int _rupees)
    {
        m_ShowRupees.text = "";
        if (_rupees < 100)
        {
            m_ShowRupees.text += "0";
            if (_rupees < 10)
            {
                m_ShowRupees.text += "0";
            }
        }
        m_ShowRupees.text += _rupees.ToString();
    }

    //change keys on HUD, ref int passed by Link Data
    public void ChangeKeys(ref int _keys)
    {
        m_ShowKeys.text = _keys.ToString();
    }

    public void ChangeHealth(ref int _health)
    {
        switch (_health)
        {
            case 6:
                m_Heart0.sprite = m_FullHeart;
                m_Heart1.sprite = m_FullHeart;
                m_Heart2.sprite = m_FullHeart;
                break;
            case 5:
                m_Heart0.sprite = m_FullHeart;
                m_Heart1.sprite = m_FullHeart;
                m_Heart2.sprite = m_HalfHeart;
                break;
            case 4:
                m_Heart0.sprite = m_FullHeart;
                m_Heart1.sprite = m_FullHeart;
                m_Heart2.sprite = m_EmptyHeart;
                break;
            case 3:
                m_Heart0.sprite = m_FullHeart;
                m_Heart1.sprite = m_HalfHeart;
                m_Heart2.sprite = m_EmptyHeart;
                break;
            case 2:
                m_Heart0.sprite = m_FullHeart;
                m_Heart1.sprite = m_EmptyHeart;
                m_Heart2.sprite = m_EmptyHeart;
                break;
            case 1:
                m_Heart0.sprite = m_HalfHeart;
                m_Heart1.sprite = m_EmptyHeart;
                m_Heart2.sprite = m_EmptyHeart;
                break;
            case 0:
                m_Heart0.sprite = m_EmptyHeart;
                m_Heart1.sprite = m_EmptyHeart;
                m_Heart2.sprite = m_EmptyHeart;
                break;
            default:
                m_Heart0.sprite = m_EmptyHeart;
                m_Heart1.sprite = m_EmptyHeart;
                m_Heart2.sprite = m_EmptyHeart;
                break;
        }
    }



    //TODO: if half not change
    public void ChangeFuel(ref int _fuel) // every 8 fuel will load another bar
    {
        current = m_last_total / 8;
        current = Mathf.Floor(current);
        target = _fuel / 8;

        m_animation = true;

        if (current != target)
        {
            AnimBar();
        }
        else
        {
            m_animation = true;
        }

    }

    private void Update()
    {
        if (m_animation)
        {
            if (Time.time >= m_trigger_time)
            {
                AnimBar();
            }
        }
    }

   

    void AnimBar()
    {
        unit = target - current;
        current += 1 * Mathf.Sign(unit);

        if (current == target)
        {
            m_animation = false;
        }
        else
        {
            m_animation = true;
            m_trigger_time = Time.time + m_duration_time;
        }
        index = (int)current;
        m_MagicBar.sprite = m_MagicBarSprites[index];
        return;
    }

    private void Start()
    {
        m_last_total = 0;
    }

    public void EquipBoomerang()
    {
        m_Boomerang.gameObject.SetActive(true);
        m_Lantern.gameObject.SetActive(false);
    }

    public void EquipLantern()
    {
        m_Lantern.gameObject.SetActive(true);
        m_Boomerang.gameObject.SetActive(false);
    }

    public void Unequip() //unequip everything
    {
        m_Boomerang.gameObject.SetActive(false);
        m_Lantern.gameObject.SetActive(false);
    }
}