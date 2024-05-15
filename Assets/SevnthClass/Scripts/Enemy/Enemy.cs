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
    [Header("�� �ǰ� �ִϸ��̼� ���� ����")]
    public float hitBackTime = 0.5f;
    public int hitCount;
    public int maxHp;
    private int currentHP;
    private SkinnedMeshRenderer skinnMeshRenderer;
    private NavMeshAgent navMeshAgent;



    [Header("�ִϸ��̼� ���࿡ �ʿ��� ����")]
    private Animator anim;

    [Header("�׺���̼� ���� ����")]
    public float FindDistance = 6.5f;
    public float AttackRange;
    private float distance;
    public Transform target;

    public readonly string takeAnimName = "IsHit";
    public readonly string DeathAnimName = "doDeath";

    [Header("������ ���� ���� ����")]
    public bool isEnemyAttackEnable;        // ���� �����ȿ� �÷��̾ ������ True, False ��ȯ�Ѵ�.
    public bool isAttack;                  // ������ ���� ���� �� True, ������ ������ false�� ��ȯ�Ѵ�.
    public float attackCoolTime = 6.8f;            // ��Ÿ���� �ִ� ���ȿ��� ���� ������ ���Ѵ�. //
    private float attackCheckTime;          // ��Ÿ���� �����ϴ� ���� 

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
            //���� �÷��̾ ���� ���� �ȿ� �ִ��� Ȯ���ϴ� ����
            isEnemyAttackEnable = true;
            //��Ÿ�� ��� �ð� ���� -> float

            //������ ���� ���� ����Ѵ�.
            if(attackCheckTime >= attackCoolTime)
            {
                //�����Ѵ�.
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