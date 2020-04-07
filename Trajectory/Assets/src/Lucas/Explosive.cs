using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : Ammo
{
    private float radius = 10f;
    private float timeToExplode = 2f;
    private float explodeTime = float.MaxValue;

    public override void Fire(Vector3 force) {
        gameObject.SetActive(true);
        GetComponent<Rigidbody>().AddForce(force);
        StartTimer();
    }

    private void StartTimer() {
        explodeTime = Time.time + timeToExplode;
        Debug.Log("Currently "+Time.time+"; Will explode at "+explodeTime);
    }

    void FixedUpdate() {
        if(Time.time >= explodeTime) {
            Explode();
        }
    }

    private void Explode() {
        Debug.Log("Exploding!");
        Destroy(gameObject);
    }
}
