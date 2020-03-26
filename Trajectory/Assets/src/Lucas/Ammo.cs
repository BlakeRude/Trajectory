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
        return this;
    }

    public void Fire() {

    }

    public void UnPickUp() {

    }
}

public class Explosive : Ammo
{
    private float radius = 10f;
    private float timeToExplode = 30f;

    public void StartTimer() {

    }

    private void Explode() {

    }
}

public class Spread : Ammo
{
    private float radius = 10f;
    private int numberOfPieces = 3;
}

public class SpreadPiece: MonoBehaviour
{
    private float damage = 3f;
    private float weight = 0.5f;

    public float GetDamage() {
        return damage;
    }

    public void Fire() {

    }
}