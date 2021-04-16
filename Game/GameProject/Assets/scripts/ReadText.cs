using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class ReadText : MonoBehaviour
{
    public Text txt;
    public string[] message;
    public Animator animator;
    int prevMessage;

    private bool isOnTrigger;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("Trigger", true);
        if (message.Length == 0)
        {
            return;
        }
        if(message.Length >= 1)
        {
            txt.text = message[0];
            prevMessage = 0;
        }
        isOnTrigger = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        isOnTrigger = false;
        animator.SetBool("Trigger", false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& isOnTrigger)
        {
            if(message.Length == 1)
            {
                animator.SetBool("Trigger", false);
            }
            else
            {
                StartCoroutine(loadNextText());
            }
        }
    }
    public IEnumerator loadNextText()
    {
        animator.SetBool("TriggerText", true);
        yield return new WaitForSeconds(0.5f);
        try
        {
            
            txt.text = message[prevMessage + 1];
            prevMessage++;
        }
        catch (System.Exception)
        {
            animator.SetBool("Trigger", false);
        }
        
        animator.SetBool("TriggerText", false);
    }
}
