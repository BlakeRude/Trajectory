using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Spawn : MonoBehaviour
{
    
    public Vector3 Spawn;
    // Start is called before the first frame update
    void Start()
    {
        //delay the spawning of player to wait for randomization of base position
        Invoke("Spawning", 0.01f);
        
    }

    
    void Spawning()
    {
        Spawn= GameObject. Find("Player_Ship").transform.position;//find base and store the position
        //adjust the player position
        Spawn.x += 3;
        Spawn.y += 2;

        //assgin the player position to the player object
        transform.position = Spawn;
       
    }
}
