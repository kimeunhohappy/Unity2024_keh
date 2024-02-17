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

    // �ڷ�ƾ�� ����ؼ� �Ѿ��� �����غ��̴ϴ�.

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

    // �Ѿ��� ������ �����ϰ� ���� ������ ���� �� ����..
    // �Ǵ� Enemy�� �׾ ������ �� ���� ����ؼ� ���� �߻��մϴ�.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"�浹�� ���� ������Ʈ�� �̸� {collision.gameObject.name}");
        }
    }
}
//*************************************************************************************************************************************************************************************************
