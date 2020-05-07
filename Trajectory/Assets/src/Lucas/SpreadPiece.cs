using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadPiece: MonoBehaviour
{
    private float damage = 3f;
    private float weight = 0.5f;

    public float GetDamage() {
        return damage;
    }

    public void Fire(Vector3 force) {
        gameObject.SetActive(true);
        GetComponent<Rigidbody>().AddForce(force);
    }
}