using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class VineManager: MonoBehaviour
{
    public int BossHP = 20;
    public float BornInterval = 5;
    public int MaxVineCount = 8;
    public int InitVineNumber = 5;
    public Transform VineContainer;
    public BossTower tower;
    public int VineCount { get; set; }

    private Game game;
    private List<Vine> vineList;
    private float currBornTime = 0;
    private bool timeOut;

    private void Awake()
    {
        game = Game.instance;
        vineList = new List<Vine>(VineContainer.GetComponentsInChildren<Vine>());
        vineList.ForEach(vine => { vine.Clear(); });
        VineCount = 0;
        for(var i = 0; i < InitVineNumber; i++)
        {
            BornNewVine();
        }
    }

    private void Start()
    {
        BossHPChange();
    }

    public void Update()
    {
        if(timeOut)
            return;
        currBornTime += Time.deltaTime;
        if(currBornTime >= BornInterval)
        {
            currBornTime = 0;
            BornNewVine();
        }
    }

    private float oldTime;
    public void TimeOut()
    {
        timeOut = true;
        oldTime = currBornTime;
        currBornTime = 0;
        vineList.ForEach(vine => vine.TimeOut());
    }

    public void Resume(bool reset = false)
    {
        if (!reset)
            currBornTime = oldTime;
        timeOut = false;
        vineList.ForEach(vine => vine.Resume());
    }

    public void BornNewVine()
    {
        VineCount++;
        game.OnBornNewVine();
        if (VineCountOver)
            return;                         // GameOver
        vineList[vineList.Count - VineCount].BeenBorn();
    }

    public bool VineCountOver { get { return VineCount >= vineList.Count; } }

    public void Cut(int damage)
    {
        var distance = damage;
        if (damage >= VineCount)
        {
            distance = VineCount;
            BossHP -= damage;
            tower.PlayHurt();
            BossHPChange();
            if (BossHP <= 0)
                game.CheckGameOver();
        }
        for (var i = 0; i < distance; i++)
        {
            vineList[vineList.Count - VineCount + i].BeenSlay();
        }
        VineCount -= distance;
    }

    public Vector3 GetTargetPos()
    {
        if (VineCount <= 0)
            return tower.transform.position;
        else
            return vineList[vineList.Count - VineCount - 1].transform.position;
    }

    public int GetBossHP() { return BossHP; }
    public void BossHPChange() 
    {
        game.OnBossHPChange(BossHP);
    }
}
