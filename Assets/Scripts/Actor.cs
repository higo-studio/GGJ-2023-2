using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActorType
{
    None,//通用
    Vine,
    Tower,//boss 手
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

   

    //某个actor的部分
   
    public virtual void Update()
    {

    }
}
