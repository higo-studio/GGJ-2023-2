using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTENode : MonoBehaviour
{
    public EmQTE value { get; private set; }

    public void Clear()
    {
        value = EmQTE.None;
        
    }

    public void SetData(EmQTE qte)
    {
        value = qte;
        enabled = true;
    }

    public bool isActive { get { return value != EmQTE.None; } }
}
