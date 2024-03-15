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

        Debug.Log($"���� �÷��̾��� ��ġ : {playerTransform}");

        playerTransform = GameObject.Find("Player").transform;

        Vector3 playerDirection = new Vector3(playerTransform.position.x, 0, playerTransform.position.z);
        caulateDirection = (playerDirection - transform.position).normalized;
    }

    IEnumerator SpawnBullet()
    {
        while (true)
        {
            //���ӸŴ��� isPlayerDeath üũ�ϴ� if �Լ�
            if(GameManager.Instance.IsPlayerDeath)
                yield break;
            //���� �ڵ�
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
        Debug.Log("�Ѿ��� �߻�Ǿ���");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"�浹�� ���� ������Ʈ�� �̸� {collision.gameObject.name}");
            Destroy(gameObject);
        }
    }
}