using Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public class EnemyBulletSample : MonoBehaviour
    {
        public Transform targetTransform;


        public float bulletSpeed;
        public float spawnTime = 3f;

        Vector3 caulateDirection;


        private void Start()
        {
            Initialize();
        }

        void Update()
        {
            BulletMove();
        }

        void OnEnable()
        {
            Initialize();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log($"충돌한 게임 오브젝트의 이름 {collision.gameObject.name}");

                collision.gameObject.GetComponent<playercorooler>().PlayerDeath();

                OnDestroy();
            }
        }

        private void OnDestroy()
        {
            Destroy(gameObject);
        }

        public void Initialize()
        {
            Destroy(gameObject, spawnTime);

            targetTransform = GameObject.Find("Player").transform;
            caulateDirection = (targetTransform.position - transform.position).normalized;
        }

        private void BulletMove()
        {
            transform.position += bulletSpeed * caulateDirection * Time.deltaTime;
        }

    }
}
