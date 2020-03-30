using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Spawn : MonoBehaviour
{
    public Vector3 Camera;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GetView", 0.01f);
    }

    // Update is called once per frame
    void GetView()
    {
        Camera= GameObject. Find("Player_Ship").transform.position;
        Camera.x += 5;
        Camera.y += 6;
        Camera.z += -17;

        transform.position = Camera;
       
    }
}
