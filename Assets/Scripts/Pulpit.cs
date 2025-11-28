using UnityEngine;

public class Pulpit : MonoBehaviour
{
    public float destroyTime;
    private bool hasScored = false; // Flag to prevent double scoring

    void Start()
    {
        float minTime = ConfigLoader.Instance.config.pulpit_data.min_pulpit_destroy_time;
        float maxTime = ConfigLoader.Instance.config.pulpit_data.max_pulpit_destroy_time;

        destroyTime = Random.Range(minTime, maxTime);
        Destroy(gameObject, destroyTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasScored)
        {
            hasScored = true; 

            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore();
            }
        }
    }
}
