using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Function to handle the player's death
    public void Die()
    {
        // Play death animation, trigger game over, respawn, or reload level
        Debug.Log("Player has died!");

        // Example: Restart the level (replace with your logic)
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
