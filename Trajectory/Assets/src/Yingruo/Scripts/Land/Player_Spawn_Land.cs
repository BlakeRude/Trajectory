using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Spawn_Land : MonoBehaviour
{
     public Vector3 Spawn_Land;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawningla", 0.01f);
    }

    
    void Spawningla()
    {
        Spawn_Land = GameObject. Find("Player_Castle").transform.position;
        Spawn_Land.x += 8.99f;
        Spawn_Land.y += 20.73f;
        Spawn_Land.z -= 10.65f;

        transform.position = Spawn_Land;
       
    }
}
