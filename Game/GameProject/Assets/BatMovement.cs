using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public Rigidbody2D rb;
    public float flySpeed;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    public bool left = true;
    public bool right = false;
    void Update()
    {
        if (rb.position.x < pos2.position.x+1 && rb.position.x> pos2.position.x-1)
        {
            right = true;
            left = false;
            spriteRenderer.flipX = true;
        }
        else if(rb.position.x < pos1.position.x + 1 && rb.position.x > pos1.position.x - 1)
        {
            right = false;
            left = true;
            spriteRenderer.flipX = false;

        }

        if (left)
        {
            horizontalMovement = ( -1*flySpeed * Time.deltaTime);
            MoveBat(horizontalMovement);
            
        }
        else if(right)
        {
            horizontalMovement = (flySpeed *Time.deltaTime);
            MoveBat(horizontalMovement);
        }
    }

    void MoveBat(float _horizontalMovement)
    {

        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }
}
