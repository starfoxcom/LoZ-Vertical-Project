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

    //sprites of every instance of magic bar
    public Sprite m_emptybar;
    public Sprite m_magicbar1;
    public Sprite m_magicbar2;
    public Sprite m_magicbar3;
    public Sprite m_magicbar4;
    public Sprite m_magicbar5;
    public Sprite m_magicbar6;
    public Sprite m_magicbar7;
    public Sprite m_magicbar8;
    public Sprite m_magicbar9;
    public Sprite m_magicbar10;
    public Sprite m_magicbar11;
    public Sprite m_magicbar12;
    public Sprite m_magicbar13;
    public Sprite m_magicbar14;
    public Sprite m_magicbar15;
    public Sprite m_magicbar16;
   

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
    private float fueldiv;

    //TODO: Erase this int when changefuel() is complete
    public int fuel;

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
        fueldiv = (float)_fuel;
        fueldiv /= 8;
        Debug.Log(fueldiv);

        if(fuel > _fuel)
        {

        }



        if(_fuel == 126)
        {
            m_MagicBar.sprite = m_FullHeart;
        }


    }

    
}
