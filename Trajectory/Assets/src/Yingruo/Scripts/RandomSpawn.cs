using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public Vector3[] positions;
   //create an array of positions of which we want to assign to the objects
    void Start()
    {
        int randomNumber = Random.Range(0, positions.Length);
        /*declare randomNumber which is used as an index of the array and set it to
        a random number between 0 and the length of the array */

        transform.position = positions[randomNumber];
        //assign the position indexed by randomNumber to the object
    }


}
