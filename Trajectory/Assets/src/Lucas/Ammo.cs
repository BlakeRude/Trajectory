using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private float damage = 5f;
    private float weight = 1f;

    public float GetDamage() {
        return damage;
    }

    public Ammo PickUp() {
        gameObject.SetActive(false);
        return this;
    }

    public virtual void Fire(Vector3 force) {
        gameObject.SetActive(true);
        GetComponent<Rigidbody>().AddForce(force);
    }

    public void UnPickUp() {

    }
}