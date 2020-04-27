using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private GameObject cannonBody;

    public float minH = -60f/180f;
    public float minV = -40f/180f;
    public float maxH = 60f/180f;
    public float maxV = 0f/180f;

    public string hAxis = "y";
    public string vAxis = "x";
    public float hMult = 1f;
    public float vMult = -1f;

    private float power = 2000f;
    private Quaternion rotationOffset;

    private Transform cannonTransform;
    private Transform cannonBodyTransform;

    public float cooldownTime = 3f;
    private float cooldownOver;
    private Ammo currentAmmo;

    public void Start() {
        cannonBody = GameObject.Find("Small_cannon");
        cannonTransform = GetComponent<Transform>();
        cannonBodyTransform = cannonTransform.GetChild(0);
        rotationOffset = cannonTransform.rotation;
    }

    public void Fire() {
        Vector3 force = new Vector3(0,0,power);

        // switch(hAxis) {
        //     case "x":
        //        force.x = hMult*power*cannonTransform.rotation.x;
        //         break;
        //     case "y":
                 force.x = hMult*power*cannonTransform.rotation.y;
        //         break;
        //     case "z":
        //         force.x = hMult*power*cannonTransform.rotation.z;
        //         break;
        // }

        // switch(vAxis) {
        //     case "x":
        //        force.y = vMult*power*cannonBodyTransform.rotation.x;
        //         break;
        //     case "y":
                 force.y = vMult*power*cannonBodyTransform.rotation.y;
        //         break;
        //     case "z":
        //         force.y = vMult*power*cannonBodyTransform.rotation.z;
        //         break;
        // }
        Debug.Log(cannonTransform.rotation);
        if(!CheckCooldown()) {
            return;
        }
        if(currentAmmo != null) {
            //force = new Vector3(power*cannonTransform.rotation.y,-power*cannonBodyTransform.rotation.x,power);
            currentAmmo.Fire(force);
            currentAmmo = null;
            cooldownOver = Time.time + cooldownTime;
        }
    }

    public void AimH(float offset) {
        switch(hAxis) {
            case "x":
                if((cannonTransform.rotation.x > minH || offset > 0f) && (cannonTransform.rotation.x < maxH || offset < 0f)) {
                    cannonTransform.Rotate(offset, 0f, 0f);
                }
                break;
            case "y":
                if((cannonTransform.rotation.y > minH || offset > 0f) && (cannonTransform.rotation.y < maxH || offset < 0f)) {
                    cannonTransform.Rotate(0f, offset, 0f);
                }
                break;
            case "z":
                if((cannonTransform.rotation.z > minH || offset > 0f) && (cannonTransform.rotation.z < maxH || offset < 0f)) {
                    cannonTransform.Rotate(0f, 0f, offset);
                }
                break;
        }
    }

    public void AimV(float offset) {
        switch(vAxis) {
            case "x":
                if((cannonBodyTransform.rotation.x > minV || offset > 0f) && (cannonBodyTransform.rotation.x < maxV || offset < 0f)) {
                    cannonBodyTransform.Rotate(offset, 0f, 0f);
                }
                break;
            case "y":
                if((cannonBodyTransform.rotation.y > minV || offset > 0f) && (cannonBodyTransform.rotation.y < maxV || offset < 0f)) {
                    cannonBodyTransform.Rotate(0f, offset, 0f);
                }
                break;
            case "z":
                if((cannonBodyTransform.rotation.z > minV || offset > 0f) && (cannonBodyTransform.rotation.z < maxV || offset < 0f)) {
                    cannonBodyTransform.Rotate(0f, 0f, offset);
                }
                break;
        }
    }

    public void Load(ref Ammo toLoad) {
        currentAmmo = toLoad;
        Vector3 loadPos = GameObject.Find("Ammo_target").GetComponent<Transform>().position;
        currentAmmo.GetComponent<Transform>().position = loadPos;
    }

    private bool CheckCooldown() {
        return Time.time >= cooldownOver;
    }
}
