using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ammo : MonoBehaviour
{
    public abstract float GetDamage();

    public abstract Ammo PickUp();

    public abstract void Fire(Vector3 force);

    public abstract void UnPickUp();
}

class NullAmmo : Ammo {
    public override float GetDamage() {
        return 0f;
    }

    public override Ammo PickUp() {
        return null;
    }

    public override void Fire(Vector3 force) {
        //do nothing
    }

    public override void UnPickUp() {
        //do nothing
    }
}