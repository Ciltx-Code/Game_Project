using UnityEngine;

public class CamaraFollow : MonoBehaviour
{

    public GameObject player;
    public Rigidbody2D rb;
    public float timeOffset;
    public Vector3 posOffset;
    public bool isOnOutsideHouse;
    public float stopCameraX;
    private Vector3 velocity = Vector3.zero;
    private static Vector3 targetVelocity;

    void Update()
    {
        if(!(rb.position.x >= stopCameraX && isOnOutsideHouse))
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset + targetVelocity, ref velocity, timeOffset);
        }
        

    }

    public static void DecaleCamera(bool cote)
    {
        //true = droite
        //false = gauche
        if (cote)
        {
            targetVelocity = new Vector3(1, 0, 0);
        }
        else
        {
            targetVelocity = new Vector3(-1, 0, 0);
        }
    }
}