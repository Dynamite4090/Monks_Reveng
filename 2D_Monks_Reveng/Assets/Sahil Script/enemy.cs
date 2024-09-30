using UnityEngine;

public class Enemy : MonoBehaviour
{
    // This function is called when the enemy collides with another object
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player has collided with the enemy
        if (collision.gameObject.CompareTag("Player"))
        {
            // Call the player's death function (or any other action)
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Die();
            }
        }
    }

    // Optionally, use OnTriggerEnter if you're using triggers instead of collisions
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Die();
            }
        }
    }
}
