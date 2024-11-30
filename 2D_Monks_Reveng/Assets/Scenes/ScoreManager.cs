//using UnityEngine;
//using UnityEngine.UI;

//public class ScoreManager : MonoBehaviour
//{
//    public Text scoreText;
//    private int score;

//    void Start()
//    {
//        score = 0;
//        UpdateScoreText();
//    }

//    public void AddScore(int points)
//    {
//        score += points;
//        UpdateScoreText();
//    }

//    void UpdateScoreText()
//    {
//        scoreText.text = "Score: " + score.ToString();
//    }
//}

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Reference to the UI Text component
    public Text scoreText;

    // Internal score value
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0; // Initialize score to 0
        UpdateScoreText(); // Update the UI with the initial score
    }

    // Method to add points to the score
    public void AddScore(int points)
    {
        score += points; // Increase the score by the specified points
        UpdateScoreText(); // Update the UI
    }

    // Method to update the UI Text with the current score
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogWarning("ScoreText is not assigned in the Inspector.");
        }
    }
}
