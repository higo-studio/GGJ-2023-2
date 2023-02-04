using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class MonoBehaviourExt
{
    public static void StartCoroutineRef(this MonoBehaviour mono, ref Coroutine coroutine, IEnumerator enumerator)
    {
        if (coroutine != null)
        {
            mono.StopCoroutine(coroutine);
        }
        coroutine = mono.StartCoroutine(enumerator);
    }
}
