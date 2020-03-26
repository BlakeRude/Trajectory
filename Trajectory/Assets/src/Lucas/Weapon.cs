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

    private float cooldownTime = 3f;
    private float cooldownOver;
    private bool loaded = false;

    public void Start() {
        cannonBody = GameObject.Find("Small_cannon");
    }

    public void Fire() {
        if(!CheckCooldown() || !loaded) {
            Debug.Log("Cooled down? "+CheckCooldown()+" Loaded? "+loaded);
            return;
        }
        Debug.Log("Fire!");
        loaded = false;
        cooldownOver = Time.time + cooldownTime;
    }

    public void AimH(float offset) {
        Transform thisTransform = GetComponent<Transform>();
        if((thisTransform.rotation.y > minH || offset > 0f) && (thisTransform.rotation.y < maxH || offset < 0f)) {
            thisTransform.Rotate(0f, offset, 0f);
        }
    }

    public void AimV(float offset) {
        Transform thisTransform = GetComponent<Transform>().GetChild(0);
        if((thisTransform.rotation.x > minV || offset > 0f) && (thisTransform.rotation.x < maxV || offset < 0f)) {
            thisTransform.Rotate(offset, 0f, 0f);
        } 
    }

    public void Load(Ammo toLoad) {
        loaded = true;
    }

    private bool CheckCooldown() {
        return Time.time >= cooldownOver;
    }
}
