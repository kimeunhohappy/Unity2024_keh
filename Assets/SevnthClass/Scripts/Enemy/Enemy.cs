using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{
    [Header("적 피격 애니메이션 제어 변수")]
    public float hitBackTime = 0.5f;
    public int hitCount;
    public int maxHp;
    private int currentHP;
    private SkinnedMeshRenderer skinnMeshRenderer;
    private NavMeshAgent navMeshAgent;



    [Header("애니매이션 실행에 필요한 변수")]
    private Animator anim;

    [Header("네비게이션 제어 변수")]
    public float FindDistance = 6.5f;
    public float AttackRange;
    private float distance;
    public Transform target;

    public readonly string takeAnimName = "IsHit";
    public readonly string DeathAnimName = "doDeath";

    [Header("몬스터의 공격 제어 변수")]
    public bool isEnemyAttackEnable;        // 공격 범위안에 플레이어가 들어오면 True, False 반환한다.
    public bool isAttack;                  // 공격을 실행 중일 때 True, 공격이 끝나면 false로 반환한다.
    public float attackCoolTime = 6.8f;            // 쿨타임이 있는 동안에는 적이 공격을 못한다. //
    private float attackCheckTime;          // 쿨타임을 제어하는 변수 

    private void Awake()
    {
        LoadComponent();
    }

    private void Update()
    {
        target = FindObjectOfType<playercorooler>().gameObject.transform;

        if (FindDistance >= Vector3.Distance(transform.position, target.position))
        {
            Debug.Log(Vector3.Distance(transform.position, target.position));
            navMeshAgent.SetDestination(target.position);
        }

        attackCheckTime += Time.deltaTime;

        if(AttackRange >= Vector3.Distance(transform.position, target.position) && !isAttack)
        {
            //현재 플레이어가 공격 범위 안에 있는지 확인하는 변수
            isEnemyAttackEnable = true;
            //쿨타임 계산 시간 변수 -> float

            //공격을 할지 말지 계산한다.
            if(attackCheckTime >= attackCoolTime)
            {
                //공격한다.
                isAttack = true;
                anim.CrossFade("Attack01", 0.2f);
                attackCheckTime = 0;
            }
        }
        else
        {
            isEnemyAttackEnable = false;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, target.position);

        Gizmos.DrawWireSphere(transform.position, FindDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }

    private void LoadComponent()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        skinnMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }


    public void TakeDamge()
    {
        hitCount++;
        anim.SetBool(takeAnimName, true);
        StartCoroutine(TakeDamegeEffect());
    }

    IEnumerator TakeDamegeEffect()
    {


        yield return new WaitForSeconds(hitBackTime);

        ShakeCamera.Instance.OnShakeCamera();
        skinnMeshRenderer.material.color = Color.red;
        anim.SetBool(takeAnimName, false);
        yield return new WaitForSeconds(hitBackTime);
        skinnMeshRenderer.material.color = Color.white;

    }
}