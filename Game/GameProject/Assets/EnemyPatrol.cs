using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Rigidbody2D player;
    public Rigidbody2D enemy;
    public float speed;
    public Animator animator;
    public Transform startPosition;
    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    public float distance;
    public SpriteRenderer spriteRenderer;

    void FixedUpdate()
    {
        if(player.position.x <= enemy.position.x+ distance && player.position.x >= enemy.position.x - distance)
        {
            animator.SetBool("FindPlayer", true);
            if (player.position.x > enemy.position.x)
            {
                spriteRenderer.flipX = false;
                horizontalMovement = (1 * speed * Time.deltaTime);
                MoveEnemy(horizontalMovement);
            }
            else
            {
                spriteRenderer.flipX = true;
                horizontalMovement = (-1 * speed * Time.deltaTime);
                MoveEnemy(horizontalMovement);
            }
        }
        else
        {
            
            if (enemy.position.x < startPosition.position.x)
            {
                spriteRenderer.flipX = false;
                horizontalMovement = (1 * speed * Time.deltaTime);
                MoveEnemy(horizontalMovement);

            }
            else if (enemy.position.x > startPosition.position.x+2)
            {
                spriteRenderer.flipX = true;
                horizontalMovement = (-1 * speed * Time.deltaTime);
                MoveEnemy(horizontalMovement);
            }
            else
            {
                horizontalMovement = (0);
                MoveEnemy(horizontalMovement);
                animator.SetBool("FindPlayer", false);
            }
        }

        void MoveEnemy(float _horizontalMovement)
        {

            Vector3 targetVelocity = new Vector2(_horizontalMovement, enemy.velocity.y);
            enemy.velocity = Vector3.SmoothDamp(enemy.velocity, targetVelocity, ref velocity, .05f);
        }
    }
}
