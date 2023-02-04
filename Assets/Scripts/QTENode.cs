using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformIcon))]
public class QTENode : MonoBehaviour
{
    public EmQTE value { get; private set; }
    private PlatformIcon icon;

    public void Awake()
    {
        icon = GetComponent<PlatformIcon>();
    }

    public void Clear()
    {
        value = EmQTE.None;
        gameObject.SetActive(false);
    }

    public void SetData(EmQTE qte)
    {
        value = qte;
        icon.IconType = (eIconType)value;
        gameObject.SetActive(true);
    }

    public bool isActive { get { return value != EmQTE.None; } }
}
