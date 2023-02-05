using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartActor : Actor
{
 
    private Rigidbody2D rb;
    public int Life = 100;//血量
    public int MaxLife = 100;//最大血量

    public Animator animator;

    public List<Actor> ContackActor = new List<Actor>();
    public override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Life = MaxLife;
    }
    public Rigidbody2D GetRigidbody() { return rb; }

   
    public void UpdateState(float deltaTime)
    {
      
        //更新状态
       
       
    }
   
    //计算伤害
    public virtual void Damage(SmartActor source)
    {
      
        Life = Mathf.Clamp(Life, 0, MaxLife);
        
    }


    //获取接触的目标
    public virtual List<Actor> GetContaractActor()
    {
        return ContackActor;
    }


}
