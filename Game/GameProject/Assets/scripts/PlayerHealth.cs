using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public Rigidbody2D rb;
    private Vector2 spawn;
    private Vector2 newPosition;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        spawn = rb.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            takeDamage(20);
        }
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            reStart();
        }
    }

    void isAlive(int health)
    {

    }

    public void reStart()
    {
        rb.position = spawn;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
}
