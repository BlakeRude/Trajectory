using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceSelect : MonoBehaviour
{
    private string GameScene = "Space";
    public void StartSpace()
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

