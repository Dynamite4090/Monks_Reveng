using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the pause menu panel
    public GameObject continueButton; // Reference to the continue button
    public GameObject mainMenuButton; // Reference to the main menu button
    public GameObject exitButton; // Reference to the exit button

    private bool isPaused = false;

    void Update()
    {
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

    void PauseGame()
    {
        isPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    void ResumeGame()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1; // Resume the game
    }

    public void Continue()
    {
        ResumeGame();
    }

    public void MainMenu()
    {
        Time.timeScale = 1; // Resume time before switching scenes
        SceneManager.LoadScene("MainMenu"); // Make sure you have a scene named "MainMenu"
    }

    public void Exit()
    {
        Application.Quit(); // Quit the application
    }
}
