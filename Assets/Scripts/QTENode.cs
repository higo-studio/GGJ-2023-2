using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(PlatformIcon))]
public class QTENode : MonoBehaviour
{
    public EmQTE value { get; private set; }
    private PlatformIcon icon;

    public void Awake()
    {
        icon = GetComponent<PlatformIcon>();
    }

    public void Clear(int index)
    {
        value = EmQTE.None;
        if (index!=0)
        {
            Audio.ins.playClick(0.5f + index * 0.2f);
        }
        //gameObject.SetActive(false);
        gameObject.GetComponent<Image>().DOColor(new Color(1, 1, 1, 0), 0.2f);
        gameObject.transform.DOScale(0.06f, 0.2f).OnComplete(()=>gameObject.SetActive(false));
    }

    public void SetData(EmQTE qte)
    {
        value = qte;
        icon.IconType = (eIconType)value;
        gameObject.SetActive(true);
        gameObject.GetComponent<Image>().color = Color.white;
        gameObject.transform.localScale = Vector3.one * 0.03f;
    }

    public bool isActive { get { return value != EmQTE.None; } }
}
