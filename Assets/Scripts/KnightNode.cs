using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightNode : MonoBehaviour
{
    public Knight knight;

    public void OnAtteckEnd()
    {
        knight.OnAttenEnd();
    }
}
