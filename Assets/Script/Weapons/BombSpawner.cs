using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public MonsterHealth monsterHealth;

    public Transform ship;
    public Transform spawnPosition;
    public GameObject icePotionGameObject;

    public bool spawnNew;

    private void Start()
    {
        spawnNew = true;
    }

    private void Update()
    {
        if (spawnNew)
        {
            GameObject bombPrefab = Instantiate(icePotionGameObject, spawnPosition.position, Quaternion.identity);
            bombPrefab.transform.parent = ship.transform;
            bombPrefab.GetComponent<Bomb>().iceSpawner = GetComponent<Bomb>();
            bombPrefab.GetComponent<Bomb>().monsterHealth = monsterHealth;
            spawnNew = false;
        }
    }
}
