using UnityEngine;

public class LightningSpawn : MonoBehaviour
{
    public GameObject prefabToSpawn; // Assign your custom shader prefab here.
    public Vector3 spawnArea = new Vector3(10f, 2f, 10f); // Define the area where objects can spawn.
    public float minSpawnInterval = 0.5f; // Minimum time interval between spawns.
    public float maxSpawnInterval = 2.0f; // Maximum time interval between spawns.

    private float timer = 0.0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= Random.Range(minSpawnInterval, maxSpawnInterval))
        {
            SpawnCustomObject();
            timer = 0.0f;
        }
    }

    private void SpawnCustomObject()
    {
        if (prefabToSpawn != null)
        {
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x, spawnArea.x),
                Random.Range(-spawnArea.y, spawnArea.y),
                Random.Range(-spawnArea.z, spawnArea.z)
            );

            Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
        }
    }
}
