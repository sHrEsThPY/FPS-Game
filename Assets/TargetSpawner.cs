using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public float spawnRange = 20f;
    public int maxTargets = 5;

    void Start()
    {
        for (int i = 0; i < maxTargets; i++)
        {
            SpawnTarget();
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Target").Length < maxTargets)
        {
            SpawnTarget();
        }
    }

    void SpawnTarget()
    {
        Vector3 randomPos = new Vector3(
            Random.Range(-spawnRange, spawnRange),
            50f, 
            Random.Range(-spawnRange, spawnRange)
        );

        RaycastHit hit;

        if (Physics.Raycast(randomPos, Vector3.down, out hit, 100f))
        {
            Vector3 spawnPoint = hit.point;

            Instantiate(targetPrefab, spawnPoint, Quaternion.identity);
        }
    }
}
