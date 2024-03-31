using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            Debug.Log("���͸� �����Ͽ���");
           
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamge();
        }

        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHitControoler hitControoler = other.gameObject.GetComponent<PlayerHitControoler>();
            hitControoler.TakeDamage();
        }
    }
}