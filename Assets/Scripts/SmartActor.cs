using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartActor : Actor
{
 
    private Rigidbody2D rb;
    public int Life = 100;//Ѫ��
    public int MaxLife = 100;//���Ѫ��

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
      
        //����״̬
       
       
    }
   
    //�����˺�
    public virtual void Damage(SmartActor source)
    {
      
        Life = Mathf.Clamp(Life, 0, MaxLife);
        
    }


    //��ȡ�Ӵ���Ŀ��
    public virtual List<Actor> GetContaractActor()
    {
        return ContackActor;
    }


}
