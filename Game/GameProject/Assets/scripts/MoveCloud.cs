using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;

    void FixedUpdate()
    {
        horizontalMovement = (1 * speed * Time.deltaTime);
        CloudMovement(horizontalMovement);
    }

    void CloudMovement(float _horizontalMovement)
    {

        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }
}
