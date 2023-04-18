using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Play audio when fruit spawns
/// </summary>
public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSource;     // Component to play audio
    public AudioClip audioClip;
    public bool playAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();        // Fetch audioSource component
        playAudio = true;
    }

    void Update()
    {
        /*if (playAudio)
        {
            //Play the audio you attach to the AudioSource component
            audioSource.PlayOneShot(audioClip);
            
            //audioSource.Play();
        }*/

        Invoke("PlaySound", 3.0f);
    }

    
    void PlaySound()
    {
        // play
        if (!GetComponent<AudioSource>())
        {
            gameObject.AddComponent<AudioSource>();
        }
        if (audioClip)
        {
            audioSource.PlayOneShot(audioClip, 0.7f);
        }  
    }
}
