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
            Destroy(other.gameObject);
            other.gameObject.SetActiveq(false);
        }
    }
}