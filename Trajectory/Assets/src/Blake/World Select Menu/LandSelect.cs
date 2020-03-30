using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandSelect : MonoBehaviour
{
    private string GameScene = "Land_Scene";
    public void StartLand()
    {
        //Loads scene
        SceneManager.LoadScene(GameScene);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
