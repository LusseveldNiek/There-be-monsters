using UnityEngine;

public class IcePotion : MonoBehaviour
{
    public IceSpawner iceSpawner;
    public Material frozenMaterial;
    public GameObject monster;
    public GameObject krakenScripts;
    public KrakenAnimations krakenAnimations;


    private void Start()
    {
        krakenScripts = GameObject.Find("Kraken");
        krakenAnimations = krakenScripts.GetComponent<KrakenAnimations>();
        monster = GameObject.Find("KrakenBody");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            print("hit");
            monster.GetComponent<SkinnedMeshRenderer>().material = frozenMaterial;
            krakenAnimations.frozen = true;
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
