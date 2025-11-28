using UnityEngine;

public class Pulpit : MonoBehaviour
{
    public float destroyTime;
    private bool hasScored = false; // Flag to prevent double scoring

    void Start()
    {
        // Read times from Config
        float minTime = ConfigLoader.Instance.config.pulpit_data.min_pulpit_destroy_time;
        float maxTime = ConfigLoader.Instance.config.pulpit_data.max_pulpit_destroy_time;

        destroyTime = Random.Range(minTime, maxTime);
        Destroy(gameObject, destroyTime);
    }

    // Unity automatically calls this when another collider enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering is the Player AND if we haven't scored yet
        if (other.CompareTag("Player") && !hasScored)
        {
            hasScored = true; // Lock scoring for this specific platform
            
            // Call the AddScore function we wrote in Step 1
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore();
            }
        }
    }
}