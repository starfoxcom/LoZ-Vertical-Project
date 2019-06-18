using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//This script needs to be implemented with the "Link" Player Class to be completed
public class UI_Behaviour : MonoBehaviour
{
    //Link Stats (this stats will be passed by reference later on the project---------------------
    public int m_numRupees;
    public int m_numBombs;
    public int m_numArrows;
    public int m_numKeys;
    public int m_numHearts;
    //--------------------------------------------------------------------------------------------

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
        
    }

    // Update is called once per frame
    void Update()
    {
        RefreshStats();  
    }

    //function that gets the stats of link and write it on the hud every frame;
    void RefreshStats()
    {
        m_ShowRupees.text = m_numRupees.ToString();
        m_ShowBombs.text = m_numBombs.ToString();
        m_ShowArrows.text = m_numArrows.ToString();
        m_ShowKeys.text = m_numKeys.ToString();
        m_ShowwHearts.text = m_numHearts.ToString();
    }

}
