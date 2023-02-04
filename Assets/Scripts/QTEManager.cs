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

    [Header("摁下空格后的连打持续时间")]
    public float ComboTime = 2.0f;
    [Header("连打后的CD时间")]
    public float CdTime = 100.0f;
    public float currCdTime { get; private set; } = 0.0f;

    public List<EmQTE> qteList { get; private set; }
    public List<EmQTE> inputList { get; private set; }
    private int checkIndex;                  
    public bool isValid { get; private set; }
    public bool isComboing { get; private set; }
    public bool isWaitingCD { get; private set; }


    private QTEManager() {
        //qteList = new ArrayList();
        qteList = new List<EmQTE>
        {
            EmQTE.Left,
            EmQTE.Right,
            EmQTE.Right
        };
        inputList = new List<EmQTE>();
        isValid = true;
    }


    public void GenerateQte()
    {

    }

    public void RefreshQte()
    {

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
    }

    private void StartCombo()
    {
        checkIndex = -1;
        isComboing = true;
        Invoke(nameof(ComboTimeOut), ComboTime);
        Game.instance.OnStartBombo();
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
        this.currCdTime = 0;
        //Invoke(nameof(CDTimeOut), CdTime);
        StartCoroutine(nameof(CuntCd));
    }


    public IEnumerable CuntCd()
    {
        while(currCdTime < CdTime)
        {
            currCdTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
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
            ComboFail();
        checkIndex++;
    }

    private void ComboFail()
    {
        isComboing = false;
        inputList.Clear();
        StartCd();
        Debug.Log("Fail");
    }

    private void FinishCombo()
    {
        isComboing = false;
        int comboLenth = Math.Max(inputList.Count - 2, 0);       
        inputList.Clear();
        StartCd();                                               
        RefreshQte();
    }

    public void DebugLog()
    {
        Debug.Log(String.Join('、', inputList.ToArray()));
    }

    
}
