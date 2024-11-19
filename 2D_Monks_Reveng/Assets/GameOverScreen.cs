using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the Game Over panel

    void Start()
    {
        gameOverPanel.SetActive(false); // Ensure Game Over panel is inactive at the start
    }

    // This method is called to show the Game Over panel
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    // Button function for Restart
    public void RestartGame()
    {
        Time.timeScale = 1; // Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart current scene
    }

    // Button function for Main Menu
    public void GoToMainMenu()
    {
        Time.timeScale = 1; // Unpause the game
        SceneManager.LoadScene("MainMenu"); // Load the Main Menu scene (ensure you have a scene named "MainMenu")
    }

    // Button function for Exit
    public void ExitGame()
    {
        Time.timeScale = 1; // Unpause the game
        Debug.Log("Exiting game...");
        Application.Quit(); // Exit the game
    }
}
