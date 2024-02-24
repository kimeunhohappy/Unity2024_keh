using FirstClass;
using Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static playercorooler;
using static Sample.PlayerControllerSample;

public class playercorooler : MonoBehaviour
{
    Animator animator;
    public enum PlayerState { Idle, Run, Death }

    PlayerState playerstate;
    public bool IsPlayerDeath = false;
    void Start()  
    {
            
    }

    void Update()
    {
        if (IsPlayerDeath == true) return;
        SetPlayerState();
        SetPlayerAnimation();
    }
    private void Initialize()
    {
        animator = GetComponentInChildren<Animator>();
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
        if (IsPlayerDeath == true) return;
        //if (animator = null) return;
        //animator.SetTrigger("Death");
        //=animator?.SetTrigger("Death");
        animator?.SetTrigger("Death");
        IsPlayerDeath = true;
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
