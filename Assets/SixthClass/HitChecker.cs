using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            Debug.Log("몬스터를 공격하였음");
           
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamge();
        }
    }
}