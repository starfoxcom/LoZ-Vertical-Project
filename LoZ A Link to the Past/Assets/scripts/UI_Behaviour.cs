using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Class that changes the text of every consumable of link when 
public class UI_Behaviour : MonoBehaviour
{
    bool finishselect = false;
    private static bool checho = false;
    private float timer; //timer to animte green pointer of select screen and the transition between startscreen and play
    private static bool yb = false;
    private static Vector3 CirclePtrPos;
    public bool bHasBoomerang = true;
    public bool bHasLantern = true;
    public bool bEquippedBoomerang = true; //if equipped link obviously current equipment is the boomerang if false then its the lantern
    private Vector3 moveStartScreenToCamera = new Vector3(-350.1852f, 161.2223f); // move start screen to  the the middle where the camera cant see and deactivate
    private Vector3 moveStartScrenOffCamera = new Vector3(-350.1852f, 879);
    private Vector3 PointBoomerang = new Vector3(-183, 221);
    private Vector3 PointLantern = new Vector3(-287, 93f);
    private  Vector3 movePointer = new Vector3(0.0f,53.0f,0.0f); //vector used to move the select screen pointer
    private Vector3 moveSelectScreen = new Vector3(0.0f, 212.0f, 0.0f); //vector used to move every component to load the screen at the center of the screen
    public Image m_Key; //text where its supposed to be the key sprite, it needs to hide when link its not in a dungeon

    public GameObject StartScreen;
    public GameObject CanvasHUD;

    public GameObject[] HUDObjects = new GameObject[16];
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

    //sprites for every possible magic bar appearance
    public Sprite[] m_MagicBarSprites = new Sprite[17];
    //Images for the Select Menu
    public Image[] m_SelectMenuImage = new Image[2]; //Array[0] Options, Array[1] Pointer 
    public Image[] m_StartMenuImage = new Image[12];
    //private int to help changefuel()
    private static int m_last_total; // last fuel 
    private static float current;
    private static int target;
    private static bool m_animation = false;
    private static float unit;

    private static int index;
    private static float m_trigger_time;
    private static float m_duration_time = 0.4f;
    
    //bools for Select Screen
    private static bool bPointerUp;
    public bool bSelectScreenActivated; // if select screen is on screen
    public bool bSelectScreenCenter;//if the select screen needs to be loaded at the center
    public bool bStartScreenActivated;
    static bool bAnimateCircle = false;

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
        if (m_animation) //if a change of the magic bar its supposed to show on screen
        {
            if (Time.time >= m_trigger_time)
            {
                AnimBar();
            }
        }

        if(Input.GetButtonDown("Button_Select") & !bSelectScreenActivated & !bStartScreenActivated)
        {
            bSelectScreenActivated = true;
            ActivateSelectScreen();
           
        }

        if (bSelectScreenActivated)
        {
            MoveSelectPointer();
        }


        if (Input.GetButtonDown("Button_Start" )& ! bStartScreenActivated & ! bSelectScreenActivated & !finishselect) 
        //if(Input.GetButtonDown("Button_Start") & ! bStartScreenActivated) 
        {
            bStartScreenActivated = true;
            ActivateStartMenu();
        }
        
        if(bStartScreenActivated)
        {
            SelectItem();
        }

        if (finishselect)
        {
            DeActivateStartScreen();
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
        m_last_total = 0; //starting 0 fuel
        bPointerUp = true; //pointer always start by the side of continue game 
        bSelectScreenActivated = false;
        bStartScreenActivated = false;
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

    public void ActivateSelectScreen()
    {
        m_SelectMenuImage[0].gameObject.SetActive(true);
        m_SelectMenuImage[1].gameObject.SetActive(true);
        bSelectScreenActivated = true;
        if(bSelectScreenCenter)
        {
            m_SelectMenuImage[0].transform.position += moveSelectScreen;
            m_SelectMenuImage[1].transform.position += moveSelectScreen;
        }
      
    }

    public void DeActivateSelectScreen()
    {
        if (bSelectScreenCenter)
        {
            m_SelectMenuImage[0].transform.position -= moveSelectScreen;
            m_SelectMenuImage[1].transform.position -= moveSelectScreen;
        }

        if(!bPointerUp)
        {
            m_SelectMenuImage[1].transform.position += movePointer; //regresar el apuntador a su posicion en continue game
            bPointerUp = true;
        }
        m_SelectMenuImage[0].gameObject.SetActive(false);
        m_SelectMenuImage[1].gameObject.SetActive(false);
        bSelectScreenActivated = false;
     
    }

    public void MoveSelectPointer() // When the Select screen is activated This function control the inputs handled
    {
        if((Input.GetAxis("XBOX_Vertical") == 1 | Input.GetAxis("Vertical") == 1) & !bPointerUp) 
        {
            m_SelectMenuImage[1].transform.position += movePointer;
            bPointerUp = true;
        }
        else if((Input.GetAxis("XBOX_Vertical") == -1 | Input.GetAxis("Vertical") == -1) & bPointerUp)
        {
            m_SelectMenuImage[1].transform.position -= movePointer;
            bPointerUp = false;
        }

        if((Input.GetButtonDown("Button_B") | Input.GetButtonDown("Button_A") | Input.GetButtonDown("Button_Start") | Input.GetButtonDown("Button_X") | Input.GetButtonDown("Button_Y"))  & bPointerUp) //Continue Game 
        {
            DeActivateSelectScreen();
        }
        else if((Input.GetButtonDown("Button_B") | Input.GetButtonDown("Button_A") | Input.GetButtonDown("Button_Start") | Input.GetButtonDown("Button_X") | Input.GetButtonDown("Button_Y")) & !bPointerUp) // Save & Quit
        {
            DeActivateSelectScreen();
        }
    }

    public void ActivateStartMenu()  //link starts with every 
    {
        StartScreen.SetActive(true);
        if(!bHasLantern & !bHasBoomerang)
        {
            m_StartMenuImage[6].gameObject.SetActive(false); //deactivate green pointer
            m_StartMenuImage[0].gameObject.SetActive(false); //deactivate boomerang icon
            m_StartMenuImage[1].gameObject.SetActive(false); //deactivate lantern icon
            m_StartMenuImage[2].gameObject.SetActive(false);
            m_StartMenuImage[3].gameObject.SetActive(false);
        }
        if(bHasBoomerang)
        {
            m_StartMenuImage[0].gameObject.SetActive(true); 
        }
        if(bHasLantern)
        {
            m_StartMenuImage[1].gameObject.SetActive(true);
        }

            if (bEquippedBoomerang) //equipped boomerang
            {
                m_StartMenuImage[6].rectTransform.anchoredPosition = PointBoomerang;
                m_StartMenuImage[3].gameObject.SetActive(false); //deactivate lantern select icon
            }
            else if (!bEquippedBoomerang & bHasLantern) // equipped lantern
            {
                m_StartMenuImage[6].rectTransform.anchoredPosition = PointLantern;
                m_StartMenuImage[2].gameObject.SetActive(false);
            }

        
        m_StartMenuImage[6].gameObject.SetActive(true);
        StartScreen.transform.localPosition = moveStartScreenToCamera;
        DeActivateHUD();
        //TODO: Needs to go down to the camera
       
    }

    private void SelectItem() // needs to return something 
    {
        
        if (checho)
            {
                if (Input.GetAxis("XBOX_Horizontal") == 0 | Input.GetAxis("Horizontal") == 0)
            {
                   if (Input.GetButtonDown("Button_A") | Input.GetButtonDown("Button_B") | Input.GetButtonDown("Button_X") | Input.GetButtonDown("Button_Y"))
                {

                    DeActivateStartScreen();
                }

                else
                {
                    checho = false;
                }
               
                }
                else
                {
                    return;
                }
        }

            if ((Input.GetAxis("XBOX_Horizontal") == 1  | Input.GetAxis("Horizontal") == 1) & !checho)
            {

                CirclePtrPos = m_StartMenuImage[6].transform.localPosition;
                checho = true;

                if (CirclePtrPos == PointBoomerang) //if pointing to boomerang and link has the lantern
                {
                    if (bHasLantern)
                    {
                        m_StartMenuImage[6].rectTransform.anchoredPosition = PointLantern;
                        m_StartMenuImage[2].gameObject.SetActive(false); //boomerang 
                        m_StartMenuImage[3].gameObject.SetActive(true); //lantern select

                    }
                }

                else if (CirclePtrPos == PointLantern) //if pointing to lantern and link has the boomerang
                {
                    if (bHasBoomerang)
                    {
                        m_StartMenuImage[6].rectTransform.anchoredPosition = PointBoomerang;
                  
                        m_StartMenuImage[2].gameObject.SetActive(true); //boomerang 
                        m_StartMenuImage[3].gameObject.SetActive(false); //lantern select
                }

                }


            }
            else if (((Input.GetAxis("XBOX_Horizontal")  == -1) | Input.GetAxis("Horizontal") == -1) & !checho)
            {
                checho = true;
            CirclePtrPos = m_StartMenuImage[6].transform.localPosition;
                if (CirclePtrPos == PointBoomerang) //if pointing to boomerang and link has the lantern
                {
                    if (bHasLantern)
                    {
                        m_StartMenuImage[6].rectTransform.anchoredPosition = PointLantern;
                 
                    m_StartMenuImage[2].gameObject.SetActive(false); //boomerang 
                        m_StartMenuImage[3].gameObject.SetActive(true); //lantern select

                }
                }
                else if (CirclePtrPos == PointLantern) //if pointing to lantern and link has the boomerang
                {
                    if (bHasBoomerang)
                    {

                        m_StartMenuImage[6].rectTransform.anchoredPosition = PointBoomerang;
                        m_StartMenuImage[2].gameObject.SetActive(true); //boomerang 
                        m_StartMenuImage[3].gameObject.SetActive(false); //lantern select
                }

                }
            }
            else if(Input.GetButtonDown("Button_A") | Input.GetButtonDown("Button_B") | Input.GetButtonDown("Button_X") | Input.GetButtonDown("Button_Y"))
        {
            finishselect = true;
        }
        


    }

    void DeActivateHUD()
    {
        CanvasHUD.SetActive(false);
    }

    void ActivateHUD()
    {
        CanvasHUD.SetActive(true);
        bStartScreenActivated = false;
        finishselect = false;
    }


    void DeActivateStartScreen()
    {
        if (bHasBoomerang | bHasLantern)
        {
            if (CirclePtrPos == PointBoomerang) // if selected 
            {
                EquipBoomerang();
                bEquippedBoomerang = true;
            }

            else if (CirclePtrPos == PointLantern)
            {
                EquipLantern();
                bEquippedBoomerang = false;
            }
        }

        StartScreen.transform.position = moveStartScrenOffCamera;
        StartScreen.SetActive(false);
        m_StartMenuImage[6].gameObject.SetActive(false);
        ActivateHUD();
    }

    //void AnumCirlcePointer()
    //{
    //    if(Time.time >= m_trigger_time)
    //    {
    //        m_trigger_time += m_duration_time;
    //    }
    //    else
    //    {
    //    if (m_StartMenuImage[6].gameObject.activeSelf == false) 

    //    }
    //}

}