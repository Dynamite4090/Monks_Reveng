using UnityEngine;
using UnityEngine.SceneManagement;

public class nextscene : MonoBehaviour
{
    // Name of the next scene to load
    public string nextSceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object colliding has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if this object has the tag "Finish"
            if (gameObject.CompareTag("Finish"))
                Debug.Log("Game run");
            {
                // Load the next scene
                SceneManager.LoadScene(nextSceneName);

                
            }
        }
    }
}
