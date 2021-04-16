using UnityEngine;
using static AudioManager;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    public static bool detector;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detector = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detector = false;
    }

    public void Update()
    {
        if (PauseMenu.gameIsPaused)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (detector)
            {
                AudioManager.isLaunching = true;
                StartCoroutine(loadNextScene());
                
            }
        }
    }
    public IEnumerator loadNextScene()
    {
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
