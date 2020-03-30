using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Spawn_Space : MonoBehaviour
{
    public Vector3 Spawn_Space;
    // Start is called before the first frame update
    void Start()
    {
        //delay the spawning of player to wait for randomization of base position
        Invoke("Spawningha", 0.01f);
        
    }

    
    void Spawningha()
    {
        Spawn_Space= GameObject. Find("Player_Spaceship").transform.position;//find base and store the position
        //adjust the player position
        Spawn_Space.z -= 3.83f;
        Spawn_Space.y += 4.345f;

        //assgin the player position to the player object
        transform.position = Spawn_Space;
       
    }
}
