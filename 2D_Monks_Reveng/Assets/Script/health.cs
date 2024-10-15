using System.Collections; // Add this
using UnityEngine;
using UnityEngine.SceneManagement; // Make sure this is included

public class PlayerController : MonoBehaviour
{
    public float restartDelay = 2f; // Delay before restart
    private bool isDead = false; // To check if player has already died

    // Function to handle the player's death
    public void Die()
    {
        if (!isDead)
        {
            isDead = true; // Set player as dead
            Debug.Log("Player has died!");

            // Play the death animation
            Animator animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("Death"); // Assuming "Death" trigger is set up in Animator
            }

            // Restart the level after a delay
            Invoke("RestartLevel", restartDelay);
        }
    }

    // Function to restart the level
    void RestartLevel()
    {
        // Ensure that the scene is reloaded
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name); // This should restart the current scene
    }
}



