using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
   
    public Transform PlayerTransform;

  
    public float bulletSpeed;
  
    void Start()
    {
 
        Debug.Log($"���� �÷��̾��� ��ġ : {PlayerTransform}");

        PlayerTransform = GameObject.Find("Player").transform;

        Vector3 playerDirection = new Vector3(PlayerTransform.position.x, 0, PlayerTransform.position.z);
        caulateDirection = (playerDirection - transform.position).normalized;
    }

   
    void Update()
    {
        BulletMove();
    }

    Vector3 caulateDirection;

    private void BulletMove()
    {


        transform.position += bulletSpeed * caulateDirection * Time.deltaTime;
     }

    public void Test()
    {
        Debug.Log("�Ѿ��� �߻�Ǿ���");
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"�浹�� ���� ������Ʈ�� �̸� {collision.gameObject.name}");
    }
}
