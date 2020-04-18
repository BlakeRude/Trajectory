using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pausemenu;

    void Start()
    {
        pausemenu.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GamePaused)
            {
                ResumeGame();
            } else
            {
                PauseGame();
            }
        }
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void PauseGame()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
