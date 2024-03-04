using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpawner : MonoBehaviour
{
    public MonsterEscape monsterEscape;

    public Transform spawnPosition;
    public GameObject icePotionGameObject;

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
            icePotionPrefab.GetComponent<IcePotion>().iceSpawner = GetComponent<IceSpawner>();
            icePotionPrefab.GetComponent<IcePotion>().monsterEscape = monsterEscape;
            spawnNew = false;
        }
    }

}
