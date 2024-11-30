using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Called when the Play button is clicked
    public void PlayGame()
    {
        // Load the next scene (replace "GameScene" with your actual game scene name)
        SceneManager.LoadScene("Level(1)");
    }

    // Called when the Settings button is clicked
    public void OpenSettings()
    {
        // Add functionality for opening settings here
        Debug.Log("Settings button clicked!");
    }

    // Called when the Exit button is clicked
    public void ExitGame()
    {
        // Exit the application (won't work in the editor)
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}