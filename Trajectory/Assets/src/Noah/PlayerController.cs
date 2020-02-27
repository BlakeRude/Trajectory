﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Weapon cannon;

    public float speed;

    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cannon = GameObject.Find("Cannon").GetComponent<Weapon>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if(!cannon.currentlyAiming) {
            MovePlayer(h, v); 
        }  
    }

    private void MovePlayer(float horizontal, float vertical)
    {
        
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        rb.AddForce(movement * speed);
    }
}

