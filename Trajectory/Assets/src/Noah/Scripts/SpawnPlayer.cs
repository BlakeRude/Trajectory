using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnPlayer : MonoBehaviour
{
    public GameObject spawnLocation;
    public GameObject player;
    private Vector3 respawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("spawnPlayer", 0.01f);
    }

    private void spawnPlayer()
    {
        player = (GameObject)Resources.Load("First Person Player", typeof(GameObject));
        spawnLocation = GameObject.FindGameObjectWithTag("SpawnPoint");
        respawnLocation = player.transform.position;
        GameObject.Instantiate(player, spawnLocation.transform.position, Quaternion.identity);
    }
}
