using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pausePanel; // Drag your Pause Panel here.
    private bool isPaused = false;

    void Update()
    {
        // Toggle Pause Menu with ESC key.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true); // Show Pause Panel
        Time.timeScale = 0f;       // Freeze game time
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false); // Hide Pause Panel
        Time.timeScale = 1f;         // Resume game time
        isPaused = false;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;         // Ensure time is normal
        SceneManager.LoadScene("MainScene"); // Replace with your Main Menu scene name
    }

    public void ExitGame()
    {
        Application.Quit();          // Close the game
    }
}
