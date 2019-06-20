using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Class that changes the text of every consumable of link when 
public class UI_Behaviour : MonoBehaviour
{

    public Image m_Key; //text where its supposed to be the key sprite, it needs to hide when link its not in a dungeon

    public Image m_MagicBar; // reference to magic bar in hud canvas to change its sprite when use changefuel()

    //Image with the heart sprites from left to right, the sprite loaded will be changed depending of links health
    public Image m_Heart0;
    public Image m_Heart1;
    public Image m_Heart2;
    //--------------------------------------------------------------------------------------------------------------

    
    //
    public Sprite[] m_MagicBarSprites=new Sprite[17];

    //Sprites of hearts-------------------------------------------------------
    public Sprite m_FullHeart;
    public Sprite m_HalfHeart;
    public Sprite m_EmptyHeart;
    //------------------------------------------------------------------------

    //Hud Text where it shows the stats passed by link Data--------------------------------------------
    public Text m_ShowRupees;
    public Text m_ShowBombs;
    public Text m_ShowArrows;
    public Text m_ShowKeys;
    //--------------------------------------------------------------------------------------------

    //private int to help changefuel()
    private float m_fueldiv;
    private int m_latestfuel;
    private static int m_fuelindex;
    private int m_numofchhanges;
    //TODO: Erase this int when changefuel is tested
    public int magic_fuel;
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

    //function switch 
    public void ChangeHealth(ref int _health)
    {
        switch(_health)
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

    public void ChangeFuel(ref int _fuel) // every 8 fuel will load another bar
    {
        m_fueldiv = (float)m_latestfuel;
        m_fueldiv *= 0.125f; // this operation means the index of the sprite of magic bar on hud
        m_fueldiv = Mathf.FloorToInt(m_fueldiv);
        Debug.Log(m_fueldiv);
        m_fuelindex = (int)m_fueldiv;
        

        //add fuel
        if(m_latestfuel < _fuel)
        {
            m_numofchhanges = Mathf.FloorToInt((_fuel - m_latestfuel) * 0.125f);
            while (m_numofchhanges > 0)
            {
                m_fuelindex += 1;
                m_MagicBar.sprite = m_MagicBarSprites[m_fuelindex];
                m_numofchhanges--;
                
            }
            m_latestfuel = _fuel; // // get the latest fuel saved in a private member of this class
        }

        
        //consume fuel
        if (m_latestfuel > _fuel)
        {
            m_numofchhanges = Mathf.FloorToInt((m_latestfuel - _fuel) * 0.125f);
            while (m_numofchhanges > 0)
            {
                m_fuelindex -= 1;
                m_MagicBar.sprite = m_MagicBarSprites[m_fuelindex];
                m_numofchhanges--;
            }
            m_latestfuel = _fuel; // // get the latest fuel saved in a private member of this class
        }


        
    }

    private void Start()
    {
        m_latestfuel = 4;
        ChangeFuel(ref magic_fuel);
    }
}
