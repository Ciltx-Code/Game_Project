using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AutoMovementRight : MonoBehaviour
{
    public static bool trigger;
    
    public static float horizontalMovement;
    public static float moveSpeed;
    public static Rigidbody2D rb;
    public Animator animator;
    public static string sceneName;

    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (trigger)
        {
            horizontalMovement = 1 * moveSpeed * Time.fixedDeltaTime;
            Vector3 targetVelocity = new Vector2(horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
            if(rb.position.x >= -3)
            {
                StartCoroutine(loadNextScene());
            }
        }

    }
    public IEnumerator loadNextScene()
    {
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);

    }
}
