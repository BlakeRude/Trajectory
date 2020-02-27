using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool currentlyAiming = true;    //should default to false, but testing
    private float aimSpeed = 0.5f;
    private float minEW = -0.5f;
    private float maxEW = 0.5f;
    private float minNS = -0.4f;
    private float maxNS = 0.1f;
    private float firePower = 75.0f;

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
            ammoToLoad.transform.position = cannonBody.transform.position;
            loadedAmmo = ammoToLoad;
        }
    }

    private void Fire()
    {
        Quaternion cannonRotation = cannon.transform.rotation;
        Quaternion cannonBodyRotation = cannonBody.transform.rotation;

        Vector3 fireVector = new Vector3(cannonRotation.y*firePower, -cannonBodyRotation.x*firePower, firePower);
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
