using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Animator))]
public class Knight : MonoBehaviour
{
    public float MoveSpeed;
    private Animator animator;
    private Vector3 originPos;
    private Vector3 targetPos;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        originPos = transform.position;
    }

    public void Hold()
    {
        animator.Play("Hold");
    }

    public void Attack()
    {
        animator.Play("Attack");
    }

    public void Idle()
    {
        animator.Play("Idle");
    }

    public void OnAttenEnd()
    {
        Idle();
    }

    
    private IEnumerator MoveToTarget(Vector3 targetPos)
    {
        targetPos.y = transform.position.y;
        Vector3.Lerp(transform.position, targetPos, MoveSpeed);
        yield return null;
    }

    public void CameraShake()
    {
        Camera.main.DOShakePosition(0.1f, 3);
    }


}
