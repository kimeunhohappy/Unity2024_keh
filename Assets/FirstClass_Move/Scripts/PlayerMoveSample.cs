using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Sample
{
    public class PlayerMoveSample : MonoBehaviour
    {
        public float rotationSpeed = 15f;
        public float moveSpeed = 5f;
        
        private Rigidbody rb;
        void Update() 
        {
            MovePlayer(transform); 
        }
        public void MovePlayer(Transform target)
        {
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");

            Vector3 dir = new Vector3(h, 0, v);

            target.Translate(dir * moveSpeed * Time.deltaTime);
        }
    } 
}
