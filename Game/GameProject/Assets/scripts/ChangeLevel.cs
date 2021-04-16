using UnityEngine;
using static LevelSelection;
using static AutoMovementRight;

public class ChangeLevel : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject wall;
    public GameObject levelSelector;
    public float moveSpeed;

    private Vector3 velocity = Vector3.zero;
    public float horizontalMovement;

    public void changeLevel(string sceneName)
    {
        wall.SetActive(false);
        levelSelector.SetActive(false);
        LevelSelection.iswalking = true;
        AutoMovementRight.rb = this.rb;
        AutoMovementRight.sceneName = sceneName;
        AutoMovementRight.moveSpeed = this.moveSpeed;
        AutoMovementRight.horizontalMovement = this.horizontalMovement;
        AutoMovementRight.trigger = true;
    }
    
}
