using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    Animator animator;
    public MonsterUI monster;
    public int health = 200;
    public int maxHealth = 200;
    public int DMGMultiplier = 3;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        monster = GetComponent<MonsterUI>();
        health = maxHealth;
    }
    public void NormalDamage(int Damage)
    {
        health -= Damage;
        print("hit");
        monster.UpdateMonsterUI();
    }
    public void CritHit(int Damage)
    {
        health -= DMGMultiplier * Damage;
        print("crit");
        monster.UpdateMonsterUI();
    }
}
