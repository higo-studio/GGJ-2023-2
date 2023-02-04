using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActorType
{
    None,//ͨ��
    Vine,
    Tower,//boss ��
    Hero,
   
}

public  class Actor : MonoBehaviour
{
    private ActorType Type;
    [SerializeField]
   
    
                           // Start is called before the first frame update
    public virtual void Start()
    {

    }


   
    public  ActorType GetActorType( )
    {
        return this.Type;
    }
     
    protected void SetActorType( ActorType type)
    {
        this.Type = type;
    }

   

    //ĳ��actor�Ĳ���
   
    public virtual void Update()
    {

    }
}
