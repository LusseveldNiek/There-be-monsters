using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    private RaycastHit hit;
    public bool ableToAttack;

    void Update()
    {
        //check if boat is behind monster
        if(Physics.Raycast(transform.position, -transform.forward, out hit, 1000))
        {
            if(hit.transform != null)
            {
                if(hit.transform.gameObject.tag == "Boat")
                {
                    ableToAttack = true;
                }

                else
                {
                    ableToAttack = false;
                }
            }

            else
            {
                ableToAttack = false;
            }
        }

        //attack
        if(ableToAttack)
        {

        }
    }
}
