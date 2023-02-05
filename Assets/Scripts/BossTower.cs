using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BossTower : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayHurt()
    {
        animator.SetBool("Hurt", true);
    }

    public void PlayIdle()
    {
        //animator.SetBool("Hurt", false);
    }
}
