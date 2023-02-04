using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public enum EmVineState
{
    None, Borning, Idle, Dying
}

public class Vine : SmartActor
{
    private Tower theTower;//
    

    private float CommonCoolTime = 2;//����ʱ����
   
    private Boss2State IdleState = null;
    private Boss2State attackSate = null;
    private Boss2State currentState = null;
    private int[] cut;
    public int num = 0;//��������
    private float passedTime; // default 0
    public float targetTime;
    //private Hero hero = null;

    /*
    public override void Start()
    {
        base.Start();
        SetActorType(ActorType.Vine);
        //SenseRange = box;
        animator = GetComponent<Animator>();
        IdleState = new IdleBoss2State(this);
        attackSate = new AttackBoss2State(this);
        currentState = IdleState;
        
        cut= new int[num];//��ʼ������
        
    }
    */
   


    /*
    // Update is called once per frame
    public override void Update()
    {
      
        UpdateState(Time.deltaTime);
      
    }
    */



    /* public override void Damage()
     {

     }*/

   
    private void grow()
    {
        if (passedTime > targetTime)
        {
            //  put function here

            num++;

            //
            passedTime = 0; //enter next loop
        }
        passedTime += Time.deltaTime;

        
    }
    private void becut(int numofsame)//������ȷ������
    {
        while (numofsame >= 0)
        {
            num--;
            numofsame--;
        }

    }
    private int[] cuting()
    {
        int damage = 0;
        while(num>=damage)
        {
            damage++;
            cut[damage] = Random.Range(1, 5);//1234��Ӧ�ĸ���

        }
        return cut;
    }
    

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
    private void FixedUpdate()
    {
        grow();
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



    //////////////////////////////////////////////////////// �ָ� paoMian //////////////////////////////////////////////////////////////

    public EmVineState state { get; private set; }

    public void BeenBorn()
    {
        state = EmVineState.Borning;
        gameObject.SetActive(true);
        // TODO Animation
    }

    public void Idle()
    {
        state = EmVineState.Idle;
    }

    public void BeenSlay()
    {
        state = EmVineState.Dying;
        // TODO  callback  ( Animation    to None    gameObject.SetActive )
        gameObject.SetActive(false);
    }

    public void TimeOut()
    {

    }

    public void Resume()
    {

    }
}




