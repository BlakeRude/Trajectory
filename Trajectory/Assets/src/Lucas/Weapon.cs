using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool currentlyAiming = false;
    private float aimSpeed = 0.5f;
    private float minEW = -0.7f;
    private float maxEW = -0.2f;
    private float minNS = -0.6f;
    private float maxNS = -0.1f;
    private float firePower = 500.0f;

    private Ammo loadedAmmo;
    private GameObject cannon;
    private GameObject cannonBody;

    public void Start()
    {
        cannon = GameObject.Find("Cannon");
        cannonBody = GameObject.Find("Cannon_body");
    }

    public void Update()
    {
        if(Input.GetKey("z")) {
            if(currentlyAiming) {
                currentlyAiming = false;
            } else {
                currentlyAiming = true;
            }
        }

        float ew = Input.GetAxis("Horizontal");
        if(ew != 0 && currentlyAiming) {
            AimEW(ew);
        }

        float ns = Input.GetAxis("Vertical");
        if(ns != 0 && currentlyAiming) {
            AimNS(-ns);
        }

        float fire = Input.GetAxis("Fire1");
        if(fire != 0 && loadedAmmo != null) {
            Fire();
        }
    }

    public void LoadAmmo(Ammo ammoToLoad) {
        if(loadedAmmo == null) {
            Vector3 raw = cannonBody.transform.position;
            Vector3 pos = new Vector3(raw.x-80,raw.y+90,raw.z+40);
            ammoToLoad.transform.position = pos;
            ammoToLoad.GetComponent<Rigidbody>().useGravity = false;
            loadedAmmo = ammoToLoad;
        }
    }

    private void Fire()
    {
        Quaternion cannonRotation = cannon.transform.rotation;
        Quaternion cannonBodyRotation = cannonBody.transform.rotation;
        Debug.Log(cannonRotation);
        Vector3 fireVector = new Vector3(cannonRotation.y*firePower, -cannonBodyRotation.x*firePower, cannonRotation.x*firePower);
        loadedAmmo.GetComponent<Rigidbody>().useGravity = true;
        loadedAmmo.GetComponent<Rigidbody>().AddForce(fireVector, ForceMode.Impulse);
        loadedAmmo = null;
    }

    private void AimEW(float dir)
    {
        Quaternion curRotation = cannon.transform.rotation;
        if((curRotation.y >= minEW && dir < 0) || (curRotation.y <= maxEW && dir > 0)) {
            cannon.transform.Rotate(0,dir*aimSpeed,0);
        }
    }
    
    private void AimNS(float dir)
    {
        Quaternion curRotation = cannonBody.transform.rotation;
        if((curRotation.x >= minNS && dir < 0) || (curRotation.x <= maxNS && dir > 0)) {
            cannonBody.transform.Rotate(dir*aimSpeed,0,0);
        }
    }
}
