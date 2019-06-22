using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

  private AudioSource m_audio;

  public void PlayOneShot(AudioClip _audio_clip)
  {
    m_audio.PlayOneShot(_audio_clip);
    return;
  }
    
    // Start is called before the first frame update
    void Start()
    {
    m_audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
