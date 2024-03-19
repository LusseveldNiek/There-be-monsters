using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public MonsterTestHP monsterHealth;

    public Transform ship;
    public Transform spawnPosition;
    public GameObject bombGameObject;

    public bool spawnNew;

    private void Start()
    {
        spawnNew = true;
    }

    private void Update()
    {
        if (spawnNew)
        {
            GameObject bombPrefab = Instantiate(bombGameObject, spawnPosition.position, Quaternion.identity);
            bombPrefab.transform.parent = ship.transform;
            bombPrefab.GetComponent<Bomb>().bombSpawner = GetComponent<BombSpawner>();
            bombPrefab.GetComponent<Bomb>().monsterHealth = monsterHealth;
            spawnNew = false;
        }
    }
}
