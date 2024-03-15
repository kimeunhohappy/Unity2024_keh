using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBulletSponer : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletTransform;
    public float spawnTime = 3f;
    public Transform playerTransform;


    public float bulletSpeed;

    void Start()
    {

        Debug.Log($"현재 플레이어의 위치 : {playerTransform}");

        playerTransform = GameObject.Find("Player").transform;

        Vector3 playerDirection = new Vector3(playerTransform.position.x, 0, playerTransform.position.z);
        caulateDirection = (playerDirection - transform.position).normalized;
    }

    IEnumerator SpawnBullet()
    {
        while (true)
        {
            //게임매니저 isPlayerDeath 체크하는 if 함수
            if(GameManager.Instance.IsPlayerDeath)
                yield break;
            //생성 코드
            GameObject enemyBullet =
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);

            yield return new WaitForSeconds(spawnTime);
        }
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"충돌한 게임 오브젝트의 이름 {collision.gameObject.name}");
            Destroy(gameObject);
        }
    }
}