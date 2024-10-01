using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    // This method gets called when the player enters a trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with has the "Trap" tag
        if (other.CompareTag("Enemy"))
        {
            // Destroy the player object
            Destroy(gameObject);
        }
    }
}