using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    public GameObject levelSelector;
    public Transform t;
    public Rigidbody2D rb;
    public Animator animator;
    public static bool iswalking;
    private bool trigger;

    // Update is called once per frame
    void Update()
    {
        if(rb.position.x<=t.position.x+1 &&rb.position.x >= t.position.x - 1)
        {
            if (!iswalking)
            {
                levelSelector.SetActive(true);
                animator.SetBool("Trigger", true);
                trigger = true;
            }
            
        }
        else
        {
            if(trigger)
            {
                animator.SetBool("Trigger", false);
                //levelSelector.SetActive(false);
            }
        }
    }
}
