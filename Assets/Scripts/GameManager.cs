using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameActive = false; 

    [Header("UI References")]
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public PulpitSpawner spawner; 

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        isGameActive = false;
        Time.timeScale = 0; 
        
        if(startPanel != null) startPanel.SetActive(true);
        if(gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    public void StartGame()
    {
        isGameActive = true;
        Time.timeScale = 1;
        startPanel.SetActive(false);
        
        
        if(spawner != null) spawner.StartSpawning();
    }

    public void GameOver()
    {
        isGameActive = false;
        Time.timeScale = 0; 
        if(gameOverPanel != null) gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
