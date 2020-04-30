using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class RealAmmo : Ammo {
    private float damage = 5f;
    private float weight = 1f;

    public override float GetDamage() {
        return damage;
    }

    public override Ammo PickUp() {
        gameObject.SetActive(false);
        return this;
    }

    public override void Fire(Vector3 force) {
        gameObject.SetActive(true);
        GetComponent<Rigidbody>().AddForce(force);
    }

    public override void UnPickUp() {
        //this method would allow the player to drop the ammo they are currently holding
    }
}