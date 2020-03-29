using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Spawn : MonoBehaviour
{
    
    public Vector3 Spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawn= GameObject. Find("Player_Ship").transform.position;
        Spawn.x += 3;
        Spawn.y += 2;

        transform.position = Spawn;
       
    }
}
