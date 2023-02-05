using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Audio : MonoBehaviour
{
    public static AudioSource Audiosrc;

    private static AudioClip ScreamAudio;
    //private static AudioClip nameAudio;
   

    private void Start()
    {
        Audiosrc = GetComponent<AudioSource>();
        ScreamAudio= Resources.Load<AudioClip>("scream");
        //ScreamAudio= Resources.Load<AudioClip>("name");
    }
    public static void AudioPlayer(string audioname)
    {
        switch(audioname)
        {
            case "scream":
                Audiosrc.clip = Resources.Load<AudioClip>("name");
                break;
            /*   
                 case "name":
                     Audioplay.clip = Resources.Load<AudioClip>("name");
                 case "":
            */
            
        }
        Audiosrc.Play();
    }
   
        
        
    
}
