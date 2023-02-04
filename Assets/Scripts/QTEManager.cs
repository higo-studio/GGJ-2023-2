using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;


public enum EmQTE 
{ 
    UP = 0, DOWN = 1, Left = 2, Right = 3, Ready = 4, Enter = 5, None = -999
}

public class QTEManager: MonoBehaviour
{
    public static Hashtable name2EmQte = new Hashtable
    {
        { "W", EmQTE.UP },
        { "S", EmQTE.DOWN },
        { "A", EmQTE.Left },
        { "D", EmQTE.Right },
        { "Ready", EmQTE.Ready },
        { "Enter", EmQTE.Enter },
    };

    [Header("���¿ո����������ʱ��")]
    public float ComboTime = 2.0f;
    [Header("������CDʱ��")]
    public float CdTime = 100.0f;
    private float currCdTime = 0.0f;
    public float remainCdTime { get { return Math.Clamp(CdTime - currCdTime, 0, CdTime); } }

    public List<EmQTE> qteList { get; private set; }
    public List<EmQTE> inputList { get; private set; }
    private int checkIndex;                  
    public bool isValid { get; private set; }
    public bool isComboing { get; private set; }
    public bool isWaitingCD { get; private set; }
    private Game game;
    private System.Random random;

    private QTEManager() {
        qteList = new List<EmQTE>();
        inputList = new List<EmQTE>();
        isValid = true;
        random = new System.Random();
    }

    public void SetGameInstance(Game instance)
    {
        game = instance;
    }

    public void GenerateQte()
    {
        int qte = random.Next(0, 4);
        qteList.Add((EmQTE)qte);
    }

    public void RefreshQte()
    {
        var count = qteList.Count;
        qteList.Clear();
        for(int i = 0; i < count; i++)
        {
            GenerateQte();
        }
    }

    public void CutQte(int cutNum)
    { 
        if(cutNum >= qteList.Count)
        {
            qteList.Clear();
        }else
        {
            qteList.RemoveRange(0, cutNum);
        }
        RefreshQte();
    }

    private void StartCombo()
    {
        checkIndex = -1;
        isComboing = true;
        Invoke(nameof(ComboTimeOut), ComboTime);
        game.OnStartBombo();
    }

    private void ComboTimeOut()
    {
        if (!isComboing)
            return;
        isComboing = false;
        FinishCombo();
        Debug.Log("TimeOut");
    }

    private void StartCd()
    {
        isValid = false;
        isWaitingCD = true;
        currCdTime = 0;
        //Invoke(nameof(CDTimeOut), CdTime);
        StartCoroutine("CuntCd");
        game.ShowRemainCD();
    }


    public IEnumerator CuntCd()
    {
        while(currCdTime < CdTime)
        {
            currCdTime += Time.deltaTime;
            yield return null;
        }
        currCdTime = 0;
        CDTimeOut();
    }

    private void CDTimeOut()
    {
        isWaitingCD = false;
        isValid = true;
    }


    public void InputQTE(EmQTE qte)
    {
        if (inputList.Count <= 0 && qte != EmQTE.Ready)
            return;
        if (inputList.Count == 0 && qte == EmQTE.Ready)
            StartCombo();
        inputList.Add(qte);
        CheckCombo();
    }

    private void CheckCombo()
    {
        if (checkIndex < 0)
        {
            checkIndex++;
            return;
        }
        if (inputList.Count > 2 && (EmQTE)inputList[inputList.Count - 1] == EmQTE.Enter)
        {
            FinishCombo();
            return;
        }
        if (checkIndex >= qteList.Count || (EmQTE)qteList[checkIndex] != (EmQTE)inputList[inputList.Count - 1])
        {
            ComboFail();
            return;
        }
        checkIndex++;
        game.OnInputCombo((EmQTE)inputList[inputList.Count - 1]);
    }

    private void ComboFail()
    {
        isComboing = false;
        inputList.Clear();
        StartCd();
        game.OnComboFail();
        Debug.Log("Fail");
    }

    private void FinishCombo()
    {
        isComboing = false;
        int comboLenth = Math.Max(inputList.Count - 2, 0);       
        inputList.Clear();
        StartCd();                                               
        //RefreshQte();
        game.OnComboFinish(comboLenth);
    }

    public void DebugLog()
    {
        //Debug.Log(String.Join('��', inputList.ToArray()));
    }

    
}
