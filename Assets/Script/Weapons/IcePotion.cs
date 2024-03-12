using UnityEngine;

public class IcePotion : MonoBehaviour
{
    public MonsterEscape monsterEscape;
    public IceSpawner iceSpawner;
    public Material frozenMaterial;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            print("hit");
            collision.gameObject.GetComponent<SkinnedMeshRenderer>().material = frozenMaterial;
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
