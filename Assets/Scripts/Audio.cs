using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Audio : MonoBehaviour
{
    private AudioSource Audioplay;
    //AudioClip screamAudio = Resources.Load<AudioClip>("scream");
    //AudioClip screamAudio = Resources.Load<AudioClip>("string");

    [SerializeField]
    private AudioClip Win;
    [SerializeField]
    private AudioClip Lose;
    [SerializeField]
    private AudioClip Scream;
    [SerializeField]
    private AudioClip Attack;
    [SerializeField]
    private AudioClip Click;

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
        Audioplay.pitch = 1;
        Audioplay.Play();
    }

    public void playLose()
    {
        Audioplay.clip = Lose;
        Audioplay.pitch = 1;
        Audioplay.Play();
    }

    public void playScream()
    {
        Audioplay.clip = Scream;
        Audioplay.pitch = 1;
        Audioplay.Play();
    }

    public void playAttack()
    {
        Audioplay.clip = Attack;
        Audioplay.pitch = 1;
        Audioplay.Play();
    }

    public void playClick(float pitch = 1)
    {
        Audioplay.clip = Click;
        Audioplay.pitch = pitch;
        Audioplay.Play();
    }

}
