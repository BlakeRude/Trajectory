using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public Vector3[] positions;
    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.Range(0, positions.Length);
        transform.position = positions[randomNumber];
    }


}
