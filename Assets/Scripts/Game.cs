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
    public LabelComboTime remainCombo;
    public LabelBossHP bossHp;
    public Knight knight;

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
        vineManager.TimeOut();
        ShowRemainCombo();
        knight.Hold();
    }

    public void OnComboFinish(int damege)
    {
        comboNodes.Hide();
        qteManager.CutQte(damege);
        vineManager.Cut(damege);
        // TODO Animation Callback stop
        vineManager.Resume(true);
        KinghtAttack();
    }

    public void KinghtAttack()
    {
        knight.Attack();
    }

    public void OnComboFail()
    {
        comboNodes.Hide();
        vineManager.Resume();
        knight.Idle();
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

    public void ShowRemainCombo()
    {
        if (remainCombo != null)
        {
            remainCombo.SetActive(true);
        }
    }

    public bool isComboCD { get { return qteManager.isWaitingCD; } }
    public bool isComboing { get { return qteManager.isComboing; } }

    public float comboRemainCDTime { get { return qteManager.remainCdTime; } }
    public float comboRemainTime { get { return qteManager.remainComboTime; } }

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
        if(vineManager.VineCountOver)
        {
            Lose();
        }
        if(vineManager.BossHP <= 0)
        {
            Win();
        }
    }

    public void OnBossHPChange(int hp)
    {
        CheckGameOver();
        bossHp.UpdateHP(hp);
    }

    public void Win()
    {
        Debug.Log("Ӯ��");
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Lose()
    {
        Debug.Log("����");
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
