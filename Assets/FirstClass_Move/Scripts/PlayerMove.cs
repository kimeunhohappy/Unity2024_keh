using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FirstClass
{
    public class PlayerMove : MonoBehaviour
    {
        public float rotationSpeed = 15f;
        public float moveSpeed = 5f;

        private Rigidbody rb;
        playercorooler playercorooler;
        void Start()
        {
            
            rb = GetComponent<Rigidbody>();
            playercorooler = GetComponent<playercorooler>();

        }

        void Update()
        {

                if (GameManager.Instance.IsPlayerDeath == true) return;
                    MovePlayer();
        }

        void MovePlayer()
        {
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");

            Vector3 dir = new Vector3(h, 0, v);

            transform.Translate(dir * moveSpeed * Time.deltaTime);
        }
    } 
}
