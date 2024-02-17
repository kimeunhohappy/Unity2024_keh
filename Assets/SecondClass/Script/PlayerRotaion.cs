using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotateSpeed = 200f;

    private void Update()
    {
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float yaw = horizontal * rotateSpeed * Time.deltaTime;
    }
}

