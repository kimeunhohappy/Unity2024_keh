using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitControoler : MonoBehaviour
{
    Animator anim;

    public float currentHP;
    public float MaxHP = 3;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        currentHP = MaxHP;
    }


    public void TakeDamage() // 플레이어가 적으로 부터 데미지를 입었을 때 로직 구현
    {
        if (GameManager.Instance.IsPlayerDeath)
            return;
        anim.CrossFade("Damage", 0.2f);
        currentHP -= 1;          // 
        CheckHP();
    }

    private void CheckHP()
    {
        if (currentHP <= 0)
        {
            GameManager.Instance.IsPlayerDeath = true;
            anim.CrossFade("Die1", 0.2f);
            GameManager.Instance.GameOver();
        }
    }
}
