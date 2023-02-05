using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Audio : MonoBehaviour
{
    private AudioSource Audioplay;
    //AudioClip screamAudio = Resources.Load<AudioClip>("scream");
    //AudioClip screamAudio = Resources.Load<AudioClip>("string");

    public AudioClip Win;
    public AudioClip Lose;
    public AudioClip Scream;
    public AudioClip Attack;

    public static Audio ins;
    private void Awake()
    {
        if (!ins)
        {
            ins = this;
        }
        Audioplay = GetComponent<AudioSource>();
    }


    private void Start()
    { 
    }
    //public void AudioPlayer(string audioname)
    //{
    //    switch(audioname)
    //    {
    //        case "scream":
    //            Audioplay.clip = screamAudio;
    //            break;
    //       /*   
    //            case "":
    //            case "":
    //       */
    //    }
    //}

    public void playWin()
    {
        Audioplay.clip = Win;
        Audioplay.Play();
    }

    public void playLose()
    {
        Audioplay.clip = Lose;
        Audioplay.Play();
    }

    public void playScream()
    {
        Audioplay.clip = Scream;
        Audioplay.Play();
    }

    public void playAttack()
    {
        Audioplay.clip = Attack;
        Audioplay.Play();
    }

}
