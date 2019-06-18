using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//DONE
//This script needs to be implemented with the "Link Data" Player Class to be completed 
public class UI_Behaviour : MonoBehaviour
{
    public Link_Data m_Link_Stats;

    //DONE
    ////Link Stats (this stats will be passed by reference later on the project---------------------
  


    //Hud Text where it shows the stats passed by link--------------------------------------------
    public Text m_ShowRupees;
    public Text m_ShowBombs;
    public Text m_ShowArrows;
    public Text m_ShowKeys;
    public Text m_ShowwHearts;
    //--------------------------------------------------------------------------------------------


    // Start is called before the first frame update
    void Start()
    {
        RefreshStats();
        m_ShowBombs.text = "00";
        m_ShowArrows.text = "00";
    }

    // Update is called once per frame

    //function that gets the stats of link and write it on the hud every frame, bombs and arrows dont apply with our scope

    //this function will be called by link gameobject to change hud
    //TODO: Keys hud hides when not in a dungeon
    void RefreshStats()
    {
        //if that concatenates zeros to show three zeros always on hud when rupees is minor that 100 and double zero if minor that 10
        if(m_Link_Stats.RUPIAHS < 100)
        {
            m_ShowRupees.text = "0";
            if (m_Link_Stats.RUPIAHS < 10)
            {
                m_ShowRupees.text += "0";
            }
        }

        m_ShowRupees.text += m_Link_Stats.RUPIAHS.ToString();
        m_ShowKeys.text = m_Link_Stats.NORMAL_KEYS.ToString();
        m_ShowwHearts.text = m_Link_Stats.HEALTH.ToString();

    }

}
