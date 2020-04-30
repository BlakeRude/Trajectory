using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Spawn_Land : MonoBehaviour
{
     public Vector3 Spawn_Land;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawningla", 0.01f);// Call the function Spawningla after 0.01 frame of sec 
        //delay to call the function because we want to wait for the castle to be set first
    }

    
    void Spawningla()
    {
        Spawn_Land = GameObject. Find("Player_Castle").transform.position;
        //find the position of the base

        //modify the position according to the base
        Spawn_Land.x += 8.99f;
        Spawn_Land.y += 20.73f;
        Spawn_Land.z -= 10.65f;

        transform.position = Spawn_Land;
       //assign the position
    }
}
