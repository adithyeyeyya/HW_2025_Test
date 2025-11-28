using System.Collections;
using UnityEngine;

public class PulpitSpawner : MonoBehaviour
{
    public GameObject pulpitPrefab;
    private Vector3 nextSpawnPos = Vector3.zero;

    
    public void StartSpawning()
    {

        SpawnPulpit(Vector3.zero); 
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (GameManager.Instance.isGameActive)
        {
            float spawnTime = 2.5f; 

            if (ConfigLoader.Instance != null && ConfigLoader.Instance.config != null)
            {
                spawnTime = ConfigLoader.Instance.config.pulpit_data.pulpit_spawn_time;
            }

            yield return new WaitForSeconds(spawnTime);

            if (GameManager.Instance.isGameActive)
            {
                ChooseNextPosition();
                SpawnPulpit(nextSpawnPos);
            }
        }
    }

    void ChooseNextPosition()
    {
        Vector3[] directions = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
        Vector3 dir = directions[Random.Range(0, directions.Length)];
        nextSpawnPos += dir * 9f;
    }

    void SpawnPulpit(Vector3 pos)
    {
        if (pulpitPrefab != null) Instantiate(pulpitPrefab, pos, Quaternion.identity);
    }
}
