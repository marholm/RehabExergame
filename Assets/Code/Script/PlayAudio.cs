using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control audio
/// https://gamedevbeginner.com/how-to-play-audio-in-unity-with-examples/
/// https://forum.unity.com/threads/play-sound-at-certain-time.289900/
/// https://gamedevbeginner.com/how-to-play-audio-in-unity-with-examples/#play_repeating_sound
/// </summary>
public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSource;     // Component to play audio
    public AudioClip audioClip;         // An audio file you want to play
    
    // Start is called before the first frame update
    void Start()
    {
        // audioSource = GetComponent<AudioSource>();
        Invoke("PlaySound", 25.0f);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
