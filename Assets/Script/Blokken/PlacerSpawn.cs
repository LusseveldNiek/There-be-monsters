using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacerSpawn : MonoBehaviour
{
    public GameObject[] Obstakels;

    public Transform SpawnPositie;

    public bool IsStart;
    void Start()
    {
        if (IsStart)
        {
            SpawnNext();
        }
    }
    public void SpawnNext()
    {
        Instantiate(Obstakels[Random.Range(0, Obstakels.Length)], SpawnPositie.position, SpawnPositie.rotation);
    }
}
