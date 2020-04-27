using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControlDemo : MonoBehaviour
{
    public Weapon cannon;
    private Ammo spikeBall;
    private Ammo bombBall;
    private Ammo eyeBall;
    private Ammo inventory;
    private Ammo waterBall;
    private Ammo rocketBall;
    private Ammo brainBall;
    // Start is called before the first frame update
    void Start()
    {
        // cannon = GameObject.Find("Small_Cannon").GetComponent<Weapon>();
        // cannon = GameObject.Find("msfmc_RadarDish").GetComponent<Weapon>();
        spikeBall = GameObject.Find("SpikeBall").GetComponent<Ammo>();
        bombBall = GameObject.Find("BombBall").GetComponent<Ammo>();
        eyeBall = GameObject.Find("EyeBall").GetComponent<Ammo>();
        waterBall = GameObject.Find("WaterMElon").GetComponent<Ammo>();
        rocketBall = GameObject.Find("Rocket14").GetComponent<Ammo>();
        brainBall = GameObject.Find("Brain").GetComponent<Ammo>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if(x != 0f) {
            cannon.AimH(x);
        }

        if(y != 0f) {
            cannon.AimV(-y);
        }

        if(Input.GetKey(KeyCode.L) && inventory != null) {
            Debug.Log(inventory);
            cannon.Load(ref inventory);
            inventory = null;
        }

        if(Input.GetKey(KeyCode.F)) {
            cannon.Fire();
        }

        if(Input.GetKey(KeyCode.Alpha4) && inventory == null) {
            inventory = spikeBall.PickUp();
            Debug.Log(inventory);
        }

        if(Input.GetKey(KeyCode.Alpha5) && inventory == null) {
            inventory = bombBall.PickUp();
            Debug.Log(inventory);
        }

        if(Input.GetKey(KeyCode.Alpha6) && inventory == null) {
            inventory = eyeBall.PickUp();
            Debug.Log(inventory);
        }

        if(Input.GetKey(KeyCode.Alpha3) && inventory == null) {
            inventory = waterBall.PickUp();
            Debug.Log(inventory);
        }

        if(Input.GetKey(KeyCode.Alpha2) && inventory == null) {
            inventory = rocketBall.PickUp();
            Debug.Log(inventory);
        }

        if(Input.GetKey(KeyCode.Alpha1) && inventory == null) {
            inventory = brainBall.PickUp();
            Debug.Log(inventory);
        }
    }
}
