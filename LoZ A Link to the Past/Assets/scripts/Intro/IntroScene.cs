using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine;

public class IntroScene : MonoBehaviour
{
    public VideoPlayer intro1;
    public VideoPlayer intro2;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
       // intro1.playbackSpeed *= 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;

        if (timer > 16.8f) //time to get inputs for the first cutscene
        {
            if (Input.GetButtonDown("Button_A") | Input.GetButtonDown("Button_B") | Input.GetButtonDown("Button_X")
           | Input.GetButtonDown("Button_Y") | Input.GetButtonDown("Button_Start"))
            {
                SceneManager.LoadScene("Testing_Room_01"); //TODO: put game scene on build 
            }
        }

        if(!intro1.isPlaying)
        {
            intro1.gameObject.SetActive(false);
            intro2.gameObject.SetActive(true);
            intro2.Play();
            timer = 0;
        }

       if(intro2.isPlaying & timer > 2.0f) //time for input of the second intro
        {
            if (Input.GetButtonDown("Button_A") | Input.GetButtonDown("Button_B") | Input.GetButtonDown("Button_X")
           | Input.GetButtonDown("Button_Y") | Input.GetButtonDown("Button_Start"))
            {
                SceneManager.LoadScene("Stairs_Test"); //TODO: put game scene on build 
            }
        }
        
    }
}
