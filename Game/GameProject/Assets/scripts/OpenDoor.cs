using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform pos;
    public Animator animator;

    void Update()
    {
        if (rb.position.x > pos.position.x - 1 && rb.position.x < pos.position.x + 1)
        {
            animator.SetBool("Trigger", true);
        }
        else
        {
            animator.SetBool("Trigger", false);
        }
    }
}
