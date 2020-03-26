﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControlDemo : MonoBehaviour
{
    private Weapon cannon;
    // Start is called before the first frame update
    void Start()
    {
        cannon = GameObject.Find("Small_Cannon").GetComponent<Weapon>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if(x != 0f) {
            cannon.AimH(x);
        }

        if(y != 0f) {
            cannon.AimV(-y);
        }

        if(Input.GetKey(KeyCode.L)) {
            cannon.Load(null);
        }

        if(Input.GetKey(KeyCode.F)) {
            cannon.Fire();
        }
    }
}
