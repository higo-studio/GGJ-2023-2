using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Audio : MonoBehaviour
{
    public static AudioSource Audiosrc;

    private static AudioClip AudioClip;
    //private static AudioClip nameAudio;
   

    private void Start()
    {
        Audiosrc = GetComponent<AudioSource>();
        
        //ScreamAudio= Resources.Load<AudioClip>("name");
    }
    public static void AudioPlayer(string audioname,int mode)
    {
        switch(audioname)
        {
            case "scream":
                AudioClip = Resources.Load<AudioClip>("name");
                break;
            /*   
                 case "name":
                     Audioplay.clip = Resources.Load<AudioClip>("name");
                 case "":
            */
            
        }

        switch (mode)
        {
            case 1:
                Audiosrc.PlayOneShot(AudioClip);
                break;
            case 2:
                Audiosrc.Stop();
                break;
            case 3:
                Audiosrc.Pause();
                break;
        }
    }
   
        
        
    
}
