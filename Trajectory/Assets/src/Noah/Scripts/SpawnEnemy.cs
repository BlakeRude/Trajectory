using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * SpawnEnemy.cs
 * a class to be associated with the spawner in each level
 * I couldn't figure out how to spawn the player without having some sort
 * of spawner or scene encompassing class, and in keeping in the theme of
 * self-contained coding, I made a spawner in each scene that spawns my player
 * prefab as well as storing respawn locations
 */

public class SpawnEnemy : SpawnPlayer
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        //delaying the spawn enemy method allows the level to ranomize before spawning the enemy
        Invoke("Spawn", 0.01f);
    }

    //SpawnEnemy extends SpawnPlayer
    public void Spawn()
    {
        enemy = (GameObject)Resources.Load("Enemy", typeof(GameObject));
        spawnLocation = GameObject.FindGameObjectWithTag("EnemySpawnPoint");
        respawnLocation = spawnLocation.transform.position;
        GameObject.Instantiate(enemy, spawnLocation.transform.position, Quaternion.identity);
    }
}
