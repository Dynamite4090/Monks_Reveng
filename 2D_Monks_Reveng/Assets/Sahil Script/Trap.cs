using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage the trap deals

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object colliding is the player
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            // Apply damage to the player
            playerHealth.TakeDamage(damageAmount);
            Debug.Log("Player hit the trap and took " + damageAmount + " damage.");
        }
    }
}

