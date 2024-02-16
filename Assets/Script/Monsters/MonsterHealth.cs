using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public float health = 200;
    public void NormalDamage(float Damage)
    {
        health -= Damage;
    }
    public void CritHit(float Damage)
    {
        health -= Damage;
    }
}
