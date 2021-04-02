using UnityEngine;

public class IgonreCollision : MonoBehaviour
{
    public Collider2D col1;
    public Collider2D col2;
    void Start()
    {
        Physics2D.IgnoreCollision(col1, col2);
    }
}
