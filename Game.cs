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
    public UIHPBar bossHPBar;
    public Knight knight;

    //audio
    public static AudioSource Audiosrc;
    private static AudioClip ScreamAudio;
    private static AudioClip AudioClip;
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

    public static void AudioPlayer(string audioname)
    {
        switch (audioname)
        {
            case "scream":
                Audiosrc.clip = Resources.Load<AudioClip>("name");
                AudioClip = Resources.Load<AudioClip>("name");
                break;
                /*   
                     case "name":
    @@ -32,7 +32,19 @@ public static void AudioPlayer(string audioname)
                */

        }
        Audiosrc.PlayOneShot(AudioClip);


    }

    public void HeroAttack(int damage)
    {
        
    }
    private void Start()
    {
        Audiosrc = GetComponent<AudioSource>();
        ScreamAudio = Resources.Load<AudioClip>("scream");

        //ScreamAudio= Resources.Load<AudioClip>("name");
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

        if (bossHPBar != null)
        {
            if (bossHPBar.MaxHp == 0)
            {
                bossHPBar.CurrentHp = bossHPBar.MaxHp = hp;
                bossHPBar.Awake();
            }
            else
            {
                var delta = bossHPBar.CurrentHp - hp;
                if (delta > 0)
                {
                    bossHPBar.UIHPDamage(delta);
                }
                else
                {
                    bossHPBar.UIHPHeal(-delta);
                }
            }
        }
    }

    public void Win()
    {
        Debug.Log("????");
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Lose()
    {
        Debug.Log("????");
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
