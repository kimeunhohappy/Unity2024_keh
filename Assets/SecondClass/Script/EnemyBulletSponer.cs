using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSponer : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;
    public float spawnTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBullet());
    }

    // 코루틴을 사용해서 총알을 생성해볼겁니다.

    IEnumerator SpawnBullet()
    {
        while (true)
        {
            GameObject enemyBullet =
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);

            EnemyBullet bulletControl = enemyBullet.GetComponent<EnemyBullet>();
            bulletControl.Test();

            yield return new WaitForSeconds(spawnTime);
        }
    }

    // 총알은 게임이 시작하고 나서 게임이 끝날 때 까지..
    // 또는 Enemy가 죽어서 없어질 때 까지 계속해서 총을 발사합니다.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"충돌한 게임 오브젝트의 이름 {collision.gameObject.name}");
        }
    }
}
//*************************************************************************************************************************************************************************************************
