using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using static UnityEditor.PlayerSettings;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Knight : MonoBehaviour
{
    public float MoveSpeed;
    private Animator animator;
    private Vector3 originPos;
    private Vector3 targetPos;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if(animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
        originPos = transform.position;
    }

    public void Hold()
    {
        animator.Play("Hold");
    }

    public void Attack(Vector3 pos)
    {
        animator.Play("Attack");
        targetPos = pos;
        StartCoroutine(MoveToTarget(pos));
    }

    public void Idle()
    {
        animator.Play("Idle");
    }

    public void OnAttenEnd()
    {
        Idle();
        StartCoroutine(MoveBack(originPos));
    }

    private bool toTargetFlag = false;
    private IEnumerator MoveToTarget(Vector3 targetPos)
    {
        Debug.Log(targetPos);
        Debug.Log("move to target");
        toTargetFlag = true;
        targetPos.y = 0;
        Vector2 posXZ = new Vector2(transform.position.x, transform.position.z);
        Vector2 targetXZ = new Vector2(targetPos.x, targetPos.z);
        while(Vector2.Distance(posXZ, targetXZ) >= 1)
        {
            posXZ = new Vector2(transform.position.x, transform.position.z);
            targetPos.y = transform.position.y;
            var oldVec = transform.position;
            var newVec = Vector3.Lerp(transform.position, targetPos, MoveSpeed * Time.deltaTime);
            transform.position = newVec;
            yield return new WaitForEndOfFrame();
        }
        toTargetFlag = false;
    }

    private IEnumerator MoveBack(Vector3 targetPos)
    {
        Debug.Log("move back");
        Vector2 posXZ = new Vector2(transform.position.x, transform.position.z);
        Vector2 targetXZ = new Vector2(targetPos.x, targetPos.z);
        while (Vector2.Distance(posXZ, targetXZ) >= 1)
        {
             if(toTargetFlag)
                yield return new WaitForEndOfFrame();
            posXZ = new Vector2(transform.position.x, transform.position.z);
            targetPos.y = transform.position.y;
            var oldVec = transform.position;
            var newVec = Vector3.Lerp(transform.position, targetPos, MoveSpeed * Time.deltaTime);
            transform.position = newVec;
            yield return new WaitForEndOfFrame();
        }
    }

    public void CameraShake()
    {
        Camera.main.DOShakePosition(0.1f, 3);
    }


}
