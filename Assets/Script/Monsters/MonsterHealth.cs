using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    Animator animator;
    public MonsterUI monster;
    public int health = 200;
    public int maxHealth = 200;
    public int DMGMultiplier = 3;

    public WinSpawner win;
    public GameObject controller;

    public AnimatieHit hit;


    [Header("Bomb")]
    
    //if hit by bomb
    public bool hitByBomb;
    //amount of damage
    public int bombTimesDamage;
    //duration bomb effect
    private float bombDurationCounter;
    public float bombDuration;
    //change material monster back to normal
    public Material normalMaterial;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        monster = GetComponent<MonsterUI>();
        win = controller.GetComponent<WinSpawner>();
        hit = GetComponent<AnimatieHit>();
        health = maxHealth;
    }
    public void Update()
    {
        if (health <= 0)
        {
            win.dood = true;
            animator.SetBool("Death", true);
        }

        if (hitByBomb)
        {
            bombDurationCounter += Time.deltaTime;
            if (bombDurationCounter > bombDuration)
            {
                GetComponent<MeshRenderer>().material = normalMaterial;
                bombDurationCounter = 0;
                hitByBomb = false;
            }
        }
    }
    public void NormalDamage(int Damage)
    {
        if(hitByBomb)
        {
            Damage *= bombTimesDamage;
        }
        hit.ishit = true;
        health -= Damage;
        monster.UpdateMonsterUI();
    }
    public void CritHit(int Damage)
    {
        Damage = DMGMultiplier * Damage;
        if (hitByBomb)
        {
            Damage *= bombTimesDamage;
        }
        hit.ishit = true;
        health -= Damage;
        monster.UpdateMonsterUI();
    }
}
