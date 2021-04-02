using UnityEngine;

public class OnFourneau : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform pos;
    public Animator animator;

    void Update()
    {
        if (rb.position.x > pos.position.x - 2 && rb.position.x < pos.position.x + 2)
        {
            animator.SetBool("Trigger", true);
        }
        else
        {
            animator.SetBool("Trigger", false);
        }
    }
}
