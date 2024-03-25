using UnityEngine;

public class IceSpawner : MonoBehaviour
{
    public MonsterEscape monsterEscape;

    public Transform ship;
    public Transform spawnPosition;
    public GameObject icePotionGameObject;
    public GameObject animationObject;
    public GameObject monster;
    public bool spawnNew;

    private void Start()
    {
        spawnNew = true;
    }

    private void Update()
    {
        if(spawnNew)
        {
            GameObject icePotionPrefab = Instantiate(icePotionGameObject, spawnPosition.position, Quaternion.identity);
            icePotionPrefab.transform.parent = ship.transform;
            icePotionPrefab.GetComponent<IcePotion>().iceSpawner = GetComponent<IceSpawner>();
            icePotionPrefab.GetComponent<IcePotion>().animationObject = animationObject;
            icePotionPrefab.GetComponent<IcePotion>().monster = monster;
            spawnNew = false;
        }
    }

}
