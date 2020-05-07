using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{

    public GameObject effect; //we create a gameobject which will be the effect we prepared

    private void OnCollisionEnter(Collision collision){

        if (collision.collider.CompareTag("Surface")){

            //If the ammo collides with a gameobject tagged with "Surface"

            //Then we create that effect
            Instantiate (effect, transform.position, transform.rotation);
            //And also destroy the ammo
            Destroy(gameObject);
        }
    }
}
