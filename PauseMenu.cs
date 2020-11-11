using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject SoundLevelUi;

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                GameResume();
            }
            else
            {
                GamePause();
            }
        }
    }

    public void GameResume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void GamePause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadSetting()
    {
        SoundLevelUi.SetActive(true);
    }
    public void ClosSetting()
    {
        SoundLevelUi.SetActive(false);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Start");
    }

    
}
