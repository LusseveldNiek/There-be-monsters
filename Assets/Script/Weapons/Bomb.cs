using UnityEngine;

public class Bomb : MonoBehaviour
{
    public MonsterHealth monsterHealth;
    public BombSpawner bombSpawner;
    public Material bombHitMaterial;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            collision.gameObject.GetComponent<MeshRenderer>().material = bombHitMaterial;
            monsterHealth.hitByBomb = true;
            bombSpawner.spawnNew = true;
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
