using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class DestroyPartical : MonoBehaviour
{
    public Vine vine;
    public void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Play()
    {
        GetComponent<ParticleSystem>().Play();
        gameObject.SetActive(true);
    }

    private void OnParticleSystemStopped()
    {
        if (vine == null)
            return;
        vine.OndestroyPlayEnd();
        gameObject.SetActive(false);
    }
}
