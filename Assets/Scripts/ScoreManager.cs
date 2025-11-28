using UnityEngine;
using TMPro; // Needed for TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton to make it easy to access from other scripts
    public TextMeshProUGUI scoreText; // Reference to the UI Text component
    private int score = 0;

    void Awake()
    {
        // This ensures there is only one ScoreManager and we can access it anywhere
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        UpdateScoreUI(); // Initialize text at 0
    }

    public void AddScore()
    {
        score++;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}