using System;
using UnityEngine;

public class openChest : MonoBehaviour
{
   
    public Rigidbody2D rb;
    public Transform pos;
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        if(rb.position.x > pos.position.x-1 && rb.position.x < pos.position.x +1)
        {
            animator.SetBool("Trigger", true);
        }
    }
}
