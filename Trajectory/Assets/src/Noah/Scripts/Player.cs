using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Player.cs
 * my player class for Trajectory
 * 
 * 
 * 
 * 
 */


[System.Serializable]
public class Player : MonoBehaviour
{
    public CharacterController controller;
    private Weapon cannon;

    //in realtion to camera switching
    public Camera playerCam;
    public Camera cannonCam;
    bool inCannonView = false;

    //in realtion to in-game stats
    public static float Health = 100.0f;
    private Ammo inv;
    private Ammo melon;
    private Ammo bomb;
    public float ammoCollectDistance = 3;
    public float cannonViewDistance = 2;
    
    //in relation to player physics **
    private Vector3 Velocity;
    public float speed = 8f;

    //in relation to player falling/gravity
    public float gravity = -9.8f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    void Start()
    {
        playerSetup();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();

        if (Health <= 0)
        {
            controller.transform.position = SpawnPlayer.respawnLocation;
            Debug.Log("Respawn Location:" + SpawnPlayer.respawnLocation);

            Health = 100.0f;
        }

        //debugging info
        Debug.Log("Health:" + Health);
        Debug.Log("In Cannon View?: " +inCannonView);
        Debug.Log("Inventory: " + inv);

        handleAmmo();
        handleWeapon();
    }

    private void OnTriggerEnter(Collider misc)
    {
        Health -= 50.0f;
    }

    private void playerSetup()
    {
        cannon = GameObject.Find("CannonA").GetComponent<Weapon>();
        melon = GameObject.Find("Watermelon").GetComponent<Ammo>();
        bomb = GameObject.Find("Bomb").GetComponent<Ammo>();

        playerCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        cannonCam = GameObject.Find("Cannon Camera").GetComponent<Camera>();

        playerCam.enabled = true;
        cannonCam.enabled = false;
    }

    private void handleAmmo()
    {
        if (Input.GetKey(KeyCode.P))
        {
            inv = null;
        }

        if (inv == null && Input.GetKey(KeyCode.E))
        {
            if (Vector3.Distance(controller.transform.position, melon.transform.position) < ammoCollectDistance)
            {
                inv = melon.PickUp();
            }
            else if (Vector3.Distance(controller.transform.position, bomb.transform.position) < ammoCollectDistance)
            {
                inv = bomb.PickUp();
            }
        }
    }

    private void handleWeapon()
    {
        if ( (Vector3.Distance(controller.transform.position, cannon.transform.position) <  cannonViewDistance) && Input.GetMouseButtonDown(0) && inCannonView == false)
        {
            playerCam.enabled = !playerCam.enabled;
            cannonCam.enabled = !cannonCam.enabled;

            inCannonView = true;
        }
        else if( inCannonView == true )
        {
            if ( Input.GetMouseButtonDown(1) )
            {
                playerCam.enabled = !playerCam.enabled;
                cannonCam.enabled = !cannonCam.enabled;

                inCannonView = false;
            }
            if(Input.GetKey(KeyCode.R) && inv != null)
            {
                cannon.Load(ref inv);
                inv = null;
            }
            if(Input.GetKey(KeyCode.F))
            {
                cannon.Fire();
            }
        }
    }

    private void movePlayer()
    {
        //an invisible sphere is made under the player to check if the player in touching the gorund
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //setting the downward velocity to -2 when grounded 1)resets downward velocity 2)keeps the player on the floor
        if(isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        //x for left/right movement, z for forward/backward movement 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //vector for moving player/character
        Vector3 move = transform.right * x + transform.forward * z;

        //moves player controller and subsequently everthing that is a child to it
        controller.Move(move * speed * Time.deltaTime);

        //the below handles character gravity multiplying by deltaTime keeps the movement frame rate independent
        Velocity.y += gravity * Time.deltaTime;
        //multiplying by deltaTime twice satisfies y = 1/2g * t^2 makes falling more realistic, go metric!
        controller.Move(Velocity * Time.deltaTime);
    }

    //allows for movement without wasd controls with a player controller for test cases
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
