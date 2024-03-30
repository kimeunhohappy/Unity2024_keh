using FirstClass;
using Sample;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static playercorooler;
using static Sample.PlayerControllerSample;

public class playercorooler : MonoBehaviour
{
    Animator animator;
    public enum PlayerState { Idle, Run, Death, Attack }

    PlayerState playerstate;
    PlayerMoveSample PlayerMoveSample;
    public BoxCollider hitBox;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            Debug.Log("NPC와 충돌했습니다.");
            var Trigger = other.GetComponent<SampleTextTrigger>();
            Trigger.TriggerText();
        }
    }

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        playerstate = PlayerState.Idle;
        PlayerMoveSample = new PlayerMoveSample();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (GameManager.Instance.IsPlayerDeath == true) return;



        SetPlayerState();

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(SetAttakCoroutine());
        }

        SetPlayerAnimation();
    }

    private void SetAttack()
    {
        playerstate = PlayerState.Attack;
        hitBox.enabled = true;
        Invoke("SetAttakOff", 0.5f);
    }

    private void SetAttakOff()
    {
        hitBox.enabled = false;
    }

    IEnumerator SetAttakCoroutine()
    {
        playerstate = PlayerState.Attack;
        hitBox.enabled = true;

        yield return new WaitForSeconds(0.5f);
        hitBox.enabled = false;
    }
    private void SetPlayerAnimation()
    {
        if (playerstate == PlayerState.Idle)
        {
            PlayerIdle();
        }
        else if (playerstate == PlayerState.Run)
        {
            PlayerMove();
        }
        else if(playerstate == PlayerState.Attack)
        {
            animator.SetTrigger("doAttack");
        }
    }

    private void SetPlayerState()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        if (v != 0 || h != 0)
        {
            playerstate = PlayerState.Run;
        }
        else
        {
            playerstate = PlayerState.Idle;
        }
    }


    public void PlayerDeath()
    {
        if (GameManager.Instance.IsPlayerDeath == true) return;
        //if (animator = null) return;
        //animator.SetTrigger("Death");
        //=animator?.SetTrigger("Death");
        animator?.SetTrigger("Death");
        GameManager.Instance.GameOver();
        GameManager.Instance.IsPlayerDeath = true;
    }

    public void PlayerMove()
    {
        animator.SetBool("IsRun", true);
    }

    public void PlayerIdle()
    {
        animator.SetBool("IsRun", false);
    }
}
