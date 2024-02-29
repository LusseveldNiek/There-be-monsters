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
        monster.UpdateMonsterUI();
    }
    public void CritHit(int Damage)
    {
        health -= DMGMultiplier * Damage;
        monster.UpdateMonsterUI();
    }
}
