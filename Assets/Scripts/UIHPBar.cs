using DG.Tweening;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using System.Collections;
using UnityEngine.UI;
using System;

public class UIHPBar : MonoBehaviour
{

    public int MaxHp;
    public int CurrentHp;

    [Space]
    public Gradient gradient;
    public Color DamageColor;
    public Color HealColor;
    public Image MainBar;
    public Image FxBar;
    public Text text;
    public RectTransform GameUI;
    [Space]
    [Range(1, 20)]
    public int Value;

    Vector3 panelPos;


    public void Awake()
    {
        text.text = CurrentHp.ToString() + "/" + MaxHp.ToString();
        MainBar.fillAmount = FxBar.fillAmount = (float)CurrentHp / (float)MaxHp;
        //pos = transform.position;
        panelPos = GameUI.anchoredPosition;
    }

    public void UIHPDamage(int delta)
    {
        if (CurrentHp > 0)
        {
            CurrentHp -= delta;
            if (CurrentHp < 0)
            {
                CurrentHp = 0;
            }
            MainBar.fillAmount = (float)CurrentHp / (float)MaxHp;
            MainBar.color = gradient.Evaluate(MainBar.fillAmount);
            FxBar.color = DamageColor;

            FxBar.DOKill();
            FxBar.DOFillAmount(MainBar.fillAmount, delta * 0.05f).SetDelay(0.2f);
            text.text = CurrentHp.ToString() + "/" + MaxHp.ToString();
            //transform.DOShakePosition(0.2f, 5).OnComplete(() => { transform.position = pos; });
            GameUI.transform.DOKill();
            GameUI.anchoredPosition = panelPos; 
            GameUI.transform.DOShakePosition(0.3f, 15).OnComplete(() => { GameUI.anchoredPosition = panelPos; });
        }

    }

    public void UIHPHeal(int delta)
    {
        if (CurrentHp > 0)
        {
            CurrentHp += delta;
            if (CurrentHp > MaxHp)
            {
                Debug.Log("Target's Hp is Full");
                //目标满血，是否要限制回复道具
                CurrentHp = MaxHp;
            }
            FxBar.color = HealColor;
            FxBar.fillAmount = (float)CurrentHp / (float)MaxHp;
            DOTween.To(() => MainBar.fillAmount, x => MainBar.fillAmount = x, FxBar.fillAmount, delta * 0.05f).SetDelay(0.2f);
            DOTween.To(() => MainBar.color, x => MainBar.color = gradient.Evaluate(MainBar.fillAmount), MainBar.color, 0.1f);
            text.text = CurrentHp.ToString() + "/" + MaxHp.ToString();
            //加附加特效
            //加音效
        }
        else
        {
            //目标死亡
            Debug.Log("Target Dead1");
        }
    }



}

#if UNITY_EDITOR
[CustomEditor(typeof(UIHPBar))]
public class UIHpBarEdiotr : Editor
{
    public override void OnInspectorGUI()
    {
        var UI = target as UIHPBar;
        base.OnInspectorGUI();
        if (GUILayout.Button("伤害" + UI.Value + "HP"))
        {
            if (Application.isPlaying)
            {
                UI.UIHPDamage(UI.Value);
            }

        }
        if (GUILayout.Button("回复" + UI.Value + "HP"))
        {
            if (Application.isPlaying)
            {
                UI.UIHPHeal(UI.Value);
            }
        }
    }
}
#endif