using System;
using static LoadSpecificScene;
using UnityEngine;
using static CamaraFollow;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public float moveSpeed;
    public float airSpeed;
    public float jumpForce;

    public bool isJumping;
    public bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayer;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
   

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la sc?ne");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        CamaraFollow.DecaleCamera(true);
    }

    void Update()
    {
        if (!isGrounded)
        {
            horizontalMovement = Input.GetAxis("Horizontal") * airSpeed * Time.fixedDeltaTime;
        }
        else
        {
            horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        

        Flip(rb.velocity.x);

        float charVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", charVelocity);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer);
        MovePlayer(horizontalMovement);
    }

    

    void MovePlayer(float _horizontalMovement)
    {
        
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(-0.5f, jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            CamaraFollow.DecaleCamera(true);
            spriteRenderer.flipX = false;
            
        }else if (_velocity < -0.1f)
        {
            CamaraFollow.DecaleCamera(false);
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
