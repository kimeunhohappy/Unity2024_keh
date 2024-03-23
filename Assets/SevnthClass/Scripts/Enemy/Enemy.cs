
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("적 피격 애니메이션 제어 변수")]
    public float hitBackTime = 0.5f;
    public int hitCount;
    public int maxHP = 2;
    private int currentHP;
    private SkinnedMeshRenderer skinnMeshRenderer;
    private NavMeshAgent navMeshAgent;



    [Header("애니매이션 실행에 필요한 변수")]
    private Animator anim;

    [Header("네비게이션 제어 변수")]
    public float FindDistance;
    public float AttackRange;
    private float distance;
    public Transform target;

    public readonly string takeAnimName = "IsHit";
    public readonly string DeathAnimName = "doDeath";

    private void Awake()
    {
        LoadComponent();
    }

    private void Update()
    {
        target = FindObjectOfType<playercorooler>().gameObject.transform;

        if (FindDistance >= Vector3.Distance(transform.position, target.position))
        {
            navMeshAgent.SetDestination(target.position);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, target.position);

        Gizmos.DrawWireSphere(transform.position, FindDistance);
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