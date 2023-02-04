using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Game()
    {
        instance = this;
    }

    private void Awake()
    {
        qteManager= GetComponent<QTEManager>();
        vineManager= GetComponent<VineManager>();
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
        
    }
}
