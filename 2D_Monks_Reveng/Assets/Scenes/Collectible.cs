using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int points = 10; // Points or value this collectible gives

    // This function is called when another collider enters the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has the tag "Player"
        if (collision.CompareTag("Player"))
        {
            // Optionally, add points to player's score (assuming a GameManager script handles it)
            //GameManager.instance.AddScore(points);

            // Play a collection sound (optional, requires an AudioSource component or AudioManager)
            // AudioManager.instance.Play("CollectSound");

            // Destroy this collectible object
            Destroy(gameObject);
        }
    }
}