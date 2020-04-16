using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * SpawnPlayer.cs
 * a class to be associated with the spawner in each level
 * I couldn't figure out how to spawn the player without having some sort
 * of spawner or scene encompassing class, and in keeping in the theme of
 * self-contained coding, I made a spawner in each scene that spawns my player
 * prefab as well as storing respawn locations
 */

public class SpawnPlayer : MonoBehaviour
{
    public GameObject spawnLocation;
    public GameObject player;

    //making this static lets me use it to respawn the player in the player class
    public static Vector3 respawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        //delaying the spawn player method allows the level to ranomize before spawning the player
        Invoke("spawnPlayer", 0.01f);
    }

    private void spawnPlayer()
    {
        player = (GameObject)Resources.Load("First Person Player", typeof(GameObject));
        spawnLocation = GameObject.FindGameObjectWithTag("SpawnPoint");
        respawnLocation = spawnLocation.transform.position;
        GameObject.Instantiate(player, spawnLocation.transform.position, Quaternion.identity);
    }
}
