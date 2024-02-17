using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
   
    public Transform PlayerTransform;

  
    public float bulletSpeed;
  
    void Start()
    {
 
        Debug.Log($"현재 플레이어의 위치 : {PlayerTransform}");

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
        Debug.Log("총알이 발사되었음");
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"충돌한 게임 오브젝트의 이름 {collision.gameObject.name}");
    }
}
