using UnityEngine;
using static AudioManager;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuScript : MonoBehaviour
{
    public string levelToLoadFirst;
    public Animator animator;
    public GameObject FadeSystem;
    public GameObject settingsWindow;


    public void StartGame()
    {
        AudioManager.isLaunching = true;
        StartCoroutine(loadNextScene());
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator loadNextScene()
    {
        FadeSystem.SetActive(true);
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(levelToLoadFirst);
    }
}
