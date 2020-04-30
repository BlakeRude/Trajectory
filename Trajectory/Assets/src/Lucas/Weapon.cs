using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private GameObject cannonBody;  //the vertically-adjustable barrel of the cannon

    public float minH = -60f/180f;
    public float minV = -40f/180f;
    public float maxH = 60f/180f;
    public float maxV = 0f/180f;

    public string hAxis = "y";
    public string vAxis = "x";
    public float hMult = 1f;
    public float vMult = -1f;
    public string angleType = "quat"; //some weapons won't work with Quaternion angles, so they need to use Euler angles instead

    private float power = 2000f;

    private Transform cannonTransform;
    private Transform cannonBodyTransform;
    private Vector3 startRotation;
    private Vector3 startBodyRotation;

    public float cooldownTime = 3f;
    private float cooldownOver;
    private Ammo currentAmmo;

    public void Start() {
        cannonBody = GameObject.Find("Small_cannon");
        cannonTransform = GetComponent<Transform>();
        cannonBodyTransform = cannonTransform.GetChild(0);
        startRotation = cannonTransform.rotation.eulerAngles;
        startBodyRotation = cannonBodyTransform.rotation.eulerAngles;
    }

    public void Fire() {
        Vector3 force = new Vector3(0,0,power);

        if(angleType == "quat") {
            force.Set(power*cannonTransform.rotation.y,-power*cannonBodyTransform.rotation.x,power);
        } else {
            force.x = hMult*power*(cannonTransform.rotation.eulerAngles.y - startRotation.y)/((maxH - minH)*100f);
            force.y = vMult*power*(cannonBodyTransform.rotation.eulerAngles.z - startBodyRotation.z)/((maxV - minV)*100f);
        }

        if(!CheckCooldown()) {
            //Weapon has not cooled down yet
            return;
        }
        if(currentAmmo != null) {
            currentAmmo.Fire(force);
            currentAmmo = null;
            cooldownOver = Time.time + cooldownTime;
        }
    }

    public void AimH(float offset) {
        //Each weapon asset is built slightly differently, so this method uses the specific axis for this weapon
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
        //Each weapon asset is built slightly differently, so this method uses the specific axis for this weapon
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
