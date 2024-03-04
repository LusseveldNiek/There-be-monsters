using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePotion : MonoBehaviour
{
    public MonsterEscape monsterEscape;
    public IceSpawner iceSpawner;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            monsterEscape.isFrozen = true;
            iceSpawner.spawnNew = true;
            Destroy(gameObject);
        }
    }
}
