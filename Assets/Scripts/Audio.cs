using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Audio : MonoBehaviour
{
    private AudioSource Audioplay;
    AudioClip screamAudio = Resources.Load<AudioClip>("scream");
    //AudioClip screamAudio = Resources.Load<AudioClip>("string");
    private void Start()
    {
        Audioplay = GetComponent<AudioSource>();
   
    }
    public void AudioPlayer(string audioname)
    {
        switch(audioname)
        {
            case "scream":
                Audioplay.clip = screamAudio;
                break;
           /*   
                case "":
                case "":
           */

        }

    }
}
