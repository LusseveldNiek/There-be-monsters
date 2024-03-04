using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePotion : MonoBehaviour
{
    public MonsterEscape monsterEscape;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            monsterEscape.isFrozen = true;
            Destroy(gameObject);
        }
    }
}
