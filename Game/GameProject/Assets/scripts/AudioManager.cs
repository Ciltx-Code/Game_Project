using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static bool isLaunching = false;
    public Animator animator;
    
    void Update()
    {
        if (isLaunching)
        {
            animator.SetTrigger("Trigger");
            isLaunching = false;
        }
    }
}
