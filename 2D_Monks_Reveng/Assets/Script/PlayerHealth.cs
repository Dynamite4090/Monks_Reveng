//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;

//public class PlayerHealth : MonoBehaviour
//{
//    public int maxHealth = 100;
//    public int currentHealth;
//    public Slider healthBar;
//    public GameObject gameOverPanel; // Reference to the Game Over panel

//    void Start()
//    {
//        currentHealth = maxHealth;
//        healthBar.maxValue = maxHealth;
//        healthBar.value = currentHealth;

//        // Ensure Game Over panel is inactive at the start
//        gameOverPanel.SetActive(false);
//    }

//    public void TakeDamage(int amount)
//    {
//        currentHealth -= amount;
//        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
//        UpdateHealthBar();

//        if (currentHealth <= 0)
//        {
//            Die();
//        }
//    }

//    void UpdateHealthBar()
//    {
//        healthBar.value = currentHealth;
//    }

//    void Die()
//    {
//        Debug.Log("Player has died.");
//        gameOverPanel.SetActive(true); // Show the Game Over screen
//        Time.timeScale = 0; // Pause the game
//    }

//    // Button functions for Game Over menu
//    public void RestartGame()
//    {
//        Time.timeScale = 1; // Unpause the game
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart current scene
//    }

//    public void GoToMainMenu()
//    {
//        Time.timeScale = 1; // Unpause the game
//        SceneManager.LoadScene("MainMenu"); // Load the Main Menu scene (ensure you have a scene named "MainMenu")
//    }

//    public void ExitGame()
//    {
//        Debug.Log("Exiting game...");
//        Application.Quit(); // Exit the game
//    }
//}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections; // Add this line for IEnumerator

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthBar;
    public GameObject gameOverPanel;
    private Animator anim;
    private bool isDead = false;
   

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        gameOverPanel.SetActive(false);

        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        healthBar.value = currentHealth;
    }

    void Die()
    {
      
        Debug.Log("Player has died.");
        isDead = true;

        anim.SetTrigger("Die"); // Trigger the death animation
        gameOverPanel.SetActive(true); // Show the Game Over screen

        StartCoroutine(ShowGameOverAfterDelay(1.5f));
    }

    private IEnumerator ShowGameOverAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Time.timeScale = 0; // Pause the game after the animation plays
    }

    // Button functions for Game Over menu
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }
}







