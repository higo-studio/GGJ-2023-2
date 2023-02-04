using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Tower : SmartActor
{
    public Vine boss;
   
    public int StiffenTime = 5;
    private float currentTime = 0;
    


    public override void Start()
    {
        SetActorType(ActorType.Tower);
    }
    public override void Update()///////////////////////////////////////
    {
        if (Life == 0 && currentTime >= StiffenTime)
        {
            //boxCollider.isTrigger = true;
            //Damage();
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }
    public override void Damage(SmartActor source)
    {
        base.Damage(source);
        if (Life == 0)
        {
       
            //boxCollider.isTrigger = false;
            
            currentTime = 0;
        }
    }/////////////
}
