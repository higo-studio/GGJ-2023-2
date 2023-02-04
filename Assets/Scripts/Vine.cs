using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Vine : SmartActor
{
    public Tower theTower;//
    

    public float CommonCoolTime = 2;//����ʱ����
    private Boss2State IdleState = null;
    private Boss2State attackSate = null;
    private Boss2State currentState = null;

    

    //private Hero hero = null;

    public override void Start()
    {
        base.Start();
        SetActorType(ActorType.Vine);
        //SenseRange = box;
        animator = GetComponent<Animator>();
        IdleState = new IdleBoss2State(this);
        attackSate = new AttackBoss2State(this);
        currentState = IdleState;
    }

   


    // Update is called once per frame
    public override void Update()
    {
      
        UpdateState(Time.deltaTime);
      
    }

 

   /* public override void Damage()
    {
       
    }*/

   
    private class Boss2State
    {
        protected Animator animator
        {
            get
            {
                return boss.animator;
            }
        }
        protected Vine boss;
        public Boss2State(Vine monster)
        {
            this.boss = monster;
        }
        public virtual void Play()
        {

        }
    }

    //boss ����
    private class IdleBoss2State : Boss2State
    {
        public IdleBoss2State(Vine monster) : base(monster)
        {

        }
       
    }
        //boss ����״̬
    private class AttackBoss2State : Boss2State
    {
        public AttackBoss2State(Vine monster) : base(monster)
        {

        }
    }

}




