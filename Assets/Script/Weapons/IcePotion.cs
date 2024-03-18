using UnityEngine;

public class IcePotion : MonoBehaviour
{
    public IceSpawner iceSpawner;
    public Material frozenMaterial;
    public GameObject monster;
    public GameObject krakenScripts;
    public KrakenAnimations krakenAnimations;
    public IcePotionMonster icePotionMonster;


    private void Start()
    {
        krakenScripts = GameObject.Find("Kraken");
        krakenAnimations = krakenScripts.GetComponent<KrakenAnimations>();
        icePotionMonster = krakenScripts.GetComponentInChildren<IcePotionMonster>();
        monster = GameObject.Find("KrakenBody");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            print("hit");
            monster.GetComponent<SkinnedMeshRenderer>().materials[0].SetFloat("Dissolve", 0);
            krakenAnimations.frozen = true;
            icePotionMonster.frozen = true;
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
