using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public string loadKey = "1";
    private Weapon cannon;
    // Start is called before the first frame update
    void Start()
    {
        cannon = GameObject.Find("Cannon").GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(loadKey)) {
            cannon.LoadAmmo(this);
        }
    }
}
