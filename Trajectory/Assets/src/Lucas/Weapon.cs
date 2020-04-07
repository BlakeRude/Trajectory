using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private GameObject cannonBody;

    private float minH = -60f/180f;
    private float minV = -40f/180f;
    private float maxH = 60f/180f;
    private float maxV = 0f/180f;

    private float power = 2000f;

    private Transform cannonTransform;
    private Transform cannonBodyTransform;

    public float cooldownTime = 3f;
    private float cooldownOver;
    private Ammo currentAmmo;

    public void Start() {
        cannonBody = GameObject.Find("Small_cannon");
        cannonTransform = GetComponent<Transform>();
        cannonBodyTransform = cannonTransform.GetChild(0);
    }

    public void Fire() {
        if(!CheckCooldown()) {
            return;
        }
        if(currentAmmo != null) {
            Vector3 force = new Vector3(power*cannonTransform.rotation.y,-power*cannonBodyTransform.rotation.x,power);
            currentAmmo.Fire(force);
            currentAmmo = null;
            cooldownOver = Time.time + cooldownTime;
        }
    }

    public void AimH(float offset) {
        if((cannonTransform.rotation.y > minH || offset > 0f) && (cannonTransform.rotation.y < maxH || offset < 0f)) {
            cannonTransform.Rotate(0f, offset, 0f);
        }
    }

    public void AimV(float offset) {
        if((cannonBodyTransform.rotation.x > minV || offset > 0f) && (cannonBodyTransform.rotation.x < maxV || offset < 0f)) {
            cannonBodyTransform.Rotate(offset, 0f, 0f);
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
