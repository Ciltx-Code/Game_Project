using UnityEngine;
using UnityEngine.SceneManagement;
using static AudioManager;

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
        gameIsPaused = true;
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
        AudioManager.isLaunching = true;
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
