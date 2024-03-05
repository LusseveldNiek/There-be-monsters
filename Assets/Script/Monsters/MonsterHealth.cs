using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    Animator animator;
    public MonsterUI monster;
    public int health = 200;
    public int maxHealth = 200;
    public int DMGMultiplier = 3;

    public bool hitByBomb;
    public int bombDamage;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        monster = GetComponent<MonsterUI>();
        health = maxHealth;
    }


    public void NormalDamage(int Damage)
    {
        if(hitByBomb)
        {
            Damage += bombDamage;
        }

        health -= Damage;
        monster.UpdateMonsterUI();
    }
    public void CritHit(int Damage)
    {
        Damage -= DMGMultiplier * Damage;

        if (hitByBomb)
        {
            Damage += bombDamage;
        }

        health -= Damage;

        monster.UpdateMonsterUI();
    }
}
