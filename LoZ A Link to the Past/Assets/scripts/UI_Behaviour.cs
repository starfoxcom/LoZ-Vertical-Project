﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Class that changes the text of every consumable of link when 
public class UI_Behaviour : MonoBehaviour
{
    
    public Text m_Key; //text where its supposed to be the key sprite, it needs to hide when link its not in a dungeon
    bool bHideKey; //placeholder bool to test hide and show keys function
    
    //Hud Text where it shows the stats passed by link Data--------------------------------------------
    public Text m_ShowRupees;
    public Text m_ShowBombs;
    public Text m_ShowArrows;
    public Text m_ShowKeys;
    public Text m_ShowwHearts;
    public Text m_showMagic;
    //--------------------------------------------------------------------------------------------


    //function that disables keys hud, only use when link is not in a dungeon
    public void HideKeys()
    {
        if(bHideKey)
        {
            m_Key.gameObject.SetActive(false);
            m_ShowKeys.gameObject.SetActive(false);
        }
    }

    //function that enables key hud, only use it when link is in a dungeon
    public void ShowKeys()
    {
        if(!bHideKey)
        {
            m_Key.gameObject.SetActive(true);
            m_ShowKeys.gameObject.SetActive(true);
        }
    }


    //change rupees on HUD, ref int passed by Link Data
    public void ChangeRupees(ref int _rupees)
    {
        if (_rupees < 100)
        {
            m_ShowRupees.text = "0";
            if (_rupees < 10)
            {
                m_ShowRupees.text += "0";
            }
        }
        m_ShowRupees.text = _rupees.ToString();
    } 

    //change keys on HUD, ref int passed by Link Data
    public void ChangeKeys(ref int _keys)
    {
        m_ShowKeys.text = _keys.ToString();
    }

    public void ChangeHealth(ref int _health)
    {
        m_ShowwHearts.text = _health.ToString();
    }

    public void ChangeFuel(ref int _fuel)
    {
        m_showMagic.text = _fuel.ToString();
    }
}
