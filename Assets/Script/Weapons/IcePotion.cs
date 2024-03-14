using UnityEngine;

public class IcePotion : MonoBehaviour
{
    public MonsterEscape monsterEscape;
    public IceSpawner iceSpawner;
    public Material frozenMaterial;
    public GameObject monster;


    private void Start()
    {
        monster = GameObject.Find("KrakenBody");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            print("hit");
            monster.GetComponent<SkinnedMeshRenderer>().material = frozenMaterial;
            monsterEscape.isFrozen = true;
            iceSpawner.spawnNew = true;
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Water")
        {
            iceSpawner.spawnNew = true;
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Boat")
        {
            iceSpawner.spawnNew = true;
            Destroy(gameObject);
        }
    }
}
