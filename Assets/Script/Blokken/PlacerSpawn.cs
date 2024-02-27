using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacerSpawn : MonoBehaviour
{
    public GameObject[] Obstakels;
    public Transform SpawnPositie;
    float spawnTimer;
    public float secBetweenSpawn;
    public float secBeforeFirstSpawn;
    private void Start()
    {
        spawnTimer = secBetweenSpawn;
        spawnTimer += secBeforeFirstSpawn;
    }
    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            SpawnNext();
            spawnTimer = secBetweenSpawn;
        }
    }
    public void SpawnNext()
    {
        Instantiate(Obstakels[Random.Range(0, Obstakels.Length)], SpawnPositie.position, SpawnPositie.rotation);
    }
}
