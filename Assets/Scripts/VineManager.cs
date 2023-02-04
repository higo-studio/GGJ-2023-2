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
    public int VineCount { get; set; }

    private Game game;
    private List<Vine> vineList;
    private float currBornTime = 0;
    private bool timeOut;

    private void Awake()
    {
        game = Game.instance;
        vineList = new List<Vine>(VineContainer.GetComponentsInChildren<Vine>());
        VineCount = 0;
        for(var i = 0; i < InitVineNumber; i++)
        {
            BornNewVine();
        }
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

    public void TimeOuyt() 
    { 
        timeOut = true;
        vineList.ForEach(vine => vine.TimeOut());
    }

    public void Resume()
    {
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
            if (BossHP <= 0)
                game.CheckGameOver();
        }
        VineCount -= distance;
        for (var i = 0; i < distance; i++)
        {
            vineList[vineList.Count - i].BeenSlay();
        }
    }

    public int GetBossHP() { return BossHP; }
}
