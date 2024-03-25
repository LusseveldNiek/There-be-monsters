using UnityEngine;

public class IcePotion : MonoBehaviour
{
    public IceSpawner iceSpawner;
    public Material frozenMaterial;
    public GameObject monster;
    public KrakenAnimations krakenAnimations;
    public NessieAnimations nessieAnimations;
    public IcePotionMonster icePotionMonster;
    public GameObject soundPrefab;
    public GameObject animationObject;


    private void Start()
    {
        icePotionMonster = monster.GetComponentInChildren<IcePotionMonster>();

        if(animationObject.GetComponent<KrakenAnimations>() != null)
        {
            krakenAnimations = animationObject.GetComponent<KrakenAnimations>();
        }

        else if(animationObject.GetComponent<NessieAnimations>() != null)
        {
            nessieAnimations = animationObject.GetComponent<NessieAnimations>();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            print("hit");

            if(krakenAnimations != null)
            {
                krakenAnimations.frozen = true;
            }

            else if(krakenAnimations != null)
            {
                nessieAnimations.frozen = true;
            }

            icePotionMonster.frozen = true;
            icePotionMonster.freezeMaterial.SetFloat("_Dissolve", 0);
            iceSpawner.spawnNew = true;
            GameObject soundPrefabGameObject = Instantiate(soundPrefab, transform.position, Quaternion.identity);
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
