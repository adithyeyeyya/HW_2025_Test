using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameActive = false; 

    [Header("UI References")]
    public GameObject startPanel;
    public GameObject gameOverPanel;
    
    // Reference to the spawner to turn it on manually
    public PulpitSpawner spawner; 

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        // Pause everything at the start
        isGameActive = false;
        Time.timeScale = 0; // Freezes physics and time
        
        if(startPanel != null) startPanel.SetActive(true);
        if(gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    public void StartGame()
    {
        isGameActive = true;
        Time.timeScale = 1; // Unfreeze time
        startPanel.SetActive(false);
        
        // Tell spawner to start spawning now
        if(spawner != null) spawner.StartSpawning();
    }

    public void GameOver()
    {
        isGameActive = false;
        Time.timeScale = 0; // Freeze the game
        if(gameOverPanel != null) gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        // Reload the current scene
        Time.timeScale = 1; // Reset time before reloading
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}