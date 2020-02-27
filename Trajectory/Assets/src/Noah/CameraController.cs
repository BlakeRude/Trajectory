using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 5.0f;

    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    public float distance = 10.0f;
    private float curX = 0;
    public float sensitivityX = 0;
 
    void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }

    private void Update()
    {
        curX += Input.GetAxis("Mouse X") * sensitivityX;

    }

    //waits for player movement
    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(30.0f, curX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
