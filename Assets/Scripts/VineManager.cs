using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using System;

[Serializable]
public struct MinMaxRange
{
    public int min;
    public int max;

    public int Value => UnityEngine.Random.Range(min, max);
}

public class VineManager: MonoBehaviour
{
    public int BossHP = 20;
    public float BornInterval = 5;
    public int MaxVineCount = 8;
    public int InitVineNumber = 5;
    public Transform VineContainer;
    public BossTower tower;
    public MinMaxRange generateCountWhenBossHit;
    
    public int VineCount { get; set; }

    private Game game;
    private List<Vine> vineList;
    private float currBornTime = 0;
    private bool timeOut;
    private int speedUpGenerateCount = 0;

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
        if (speedUpGenerateCount > 0)
        {
            var interval = BornInterval / 3f;
            if (currBornTime > interval)
            {
                speedUpGenerateCount--;
                currBornTime -= interval;
                Debug.Log("Born Quick");
                BornNewVine();
            }
        }
        else
        {
            if(currBornTime >= BornInterval)
            {
                currBornTime -= BornInterval;
                BornNewVine();
            }
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

            speedUpGenerateCount = generateCountWhenBossHit.Value; 
        }
        for (var i = 0; i < distance; i++)
        {
            vineList[vineList.Count - VineCount + i].BeenSlay();
        }
        VineCount -= distance;
    }

    public int GetBossHP() { return BossHP; }
    public void BossHPChange() 
    {
        game.OnBossHPChange(BossHP);
    }
}
