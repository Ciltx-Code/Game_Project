using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseWindow;
    public GameObject settingsWindow;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print(gameIsPaused);
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    public void SettingsButton()
    {
        pauseWindow.SetActive(false);
        settingsWindow.SetActive(true);
    }

    public void QuitSettingWindow()
    {
        pauseWindow.SetActive(true);
        settingsWindow.SetActive(false);
    }

    void Paused()
    {
        pauseMenuUI.SetActive(true);
        
        Time.timeScale = 0;
        print(Time.timeScale);
        gameIsPaused = true;
        print(gameIsPaused);
        PlayerMovement.instance.enabled = false;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsWindow.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        PlayerMovement.instance.enabled = true;
    }

    public void LoadMainMenu()
    {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
