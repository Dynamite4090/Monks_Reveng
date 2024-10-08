using UnityEngine;
using UnityEngine.SceneManagement; // Needed to load new scenes

public class MainMenu : MonoBehaviour
{
    // This method will be called when the "Start" button is clicked
    public void StartGame()
    {
        // Load the game scene (ensure your game scene is added in Build Settings)
        SceneManager.LoadScene("level"); // Replace "GameScene" with the name of your game scene
    }

    // This method will be called when the "Exit" button is clicked
    public void ExitGame()
    {
        // If running in the editor, stop the play mode
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        // Quit the application
        Application.Quit();
#endif
    }
}
