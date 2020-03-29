using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeaSelect : MonoBehaviour
{
    private string GameScene = "Sea_Scene";
    public void StartSea()
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
