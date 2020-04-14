using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;

    private Vector3 Spawn;
    private Vector3 Velocity;     

    public float speed = 12f;
    public float gravity = -9.8f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float Health;

    bool isGrounded;

    void Start()
    {
        Health = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();

        if(Health <= 0)
        {
            controller.transform.position = SpawnPlayer.respawnLocation;
            Health = 100.0f;
        }
    }

    private void OnTriggerEnter(Collider misc)
    {
        Health -= 50.0f;
        Debug.Log("Health =" + Health);
    }

    private void movePlayer()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        //x for left/right movement, z for forward/backward movement 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //vector for moving player/character
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //the below handles character gravity
        Velocity.y += gravity * Time.deltaTime;
        //multiplying by deltaTime twice satisfies y = 1/2g * t^2 makes falling more realistic
        controller.Move(Velocity * Time.deltaTime);
    }

    //allows for movement without wasd controls with a player controller
    public void moveTest()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        controller.Move(Vector3.left * speed * Time.deltaTime);

        //the below handles character gravity
        Velocity.y += gravity * Time.deltaTime;
        //multiplying by deltaTime twice satisfies y = 1/2g * t^2 makes falling more realistic
        controller.Move(Velocity * Time.deltaTime);
    }
}
