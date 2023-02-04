using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Game : MonoBehaviour
{
    private static Game _instance;
    public static Game instance
    {
        get { return _instance; }
        private set { _instance = value; }
    }
    public QTEManager qteManager;
    public VineManager vineManager;
    public ComboNodes comboNodes;
    public LabelCD remainCD;

    public Game()
    {
        instance = this;
    }

    private void Awake()
    {
        qteManager = GetComponent<QTEManager>();
        vineManager = GetComponent<VineManager>();
        comboNodes = GetComponent<ComboNodes>();
        qteManager.SetGameInstance(this);
    }

    public void HeroAttack(int damage)
    {
            
    }

    public List<EmQTE> GetQTEList()
    {
        return qteManager.qteList;
    }

    public void OnStartBombo()
    {
        comboNodes.Show(GetQTEList());
    }

    public void OnComboFinish(int damege)
    {
        comboNodes.Hide();
        qteManager.CutQte(damege);
    }

    public void OnComboFail()
    {
        comboNodes.Hide();
    }

    public void OnInputCombo(EmQTE qte)
    {
        comboNodes.OnInputCombo(qte);
    }

    public void ShowRemainCD()
    {
        if(remainCD != null)
        {
            remainCD.SetActive(true);
        }
    }

    public bool isComboCD { get { return qteManager.isWaitingCD; } }

    public float comboRemainCDTime { get { return qteManager.remainCdTime; } }

    public void OnBornNewVine()
    {
        if(vineManager.VineCountOver)
        {
            // TODO
            CheckGameOver();
        }
        qteManager.GenerateQte();
    }

    public void CheckGameOver()
    {

    }
}
