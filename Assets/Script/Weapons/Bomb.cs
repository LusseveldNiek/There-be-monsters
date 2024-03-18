using UnityEngine;

public class Bomb : MonoBehaviour
{
    public MonsterHealth monsterHealth;
    public BombSpawner bombSpawner;
    public Material bombHitMaterial;
    public GameObject monster;
    public GameObject particle;

    private void Start()
    {
        monster = GameObject.Find("KrakenBody");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            monster.GetComponent<SkinnedMeshRenderer>().material = bombHitMaterial;
            monsterHealth.hitByBomb = true;
            bombSpawner.spawnNew = true;
            GameObject particlePrefab = Instantiate(particle, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Water")
        {
            bombSpawner.spawnNew = true;
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Boat")
        {
            bombSpawner.spawnNew = true;
            Destroy(gameObject);
        }
    }
}
