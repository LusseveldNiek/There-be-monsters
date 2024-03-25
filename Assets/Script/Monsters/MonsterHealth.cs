using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    Animator animator;
    public MonsterUI monster;
    public int health = 200;
    public int maxHealth = 200;
    public int DMGMultiplier = 3;
    public bool dood;
    public bool doodAnimatie;

    public WinSpawner win;
    public GameObject controller;

    public AnimatieHit hit;
    public KrakenAnimations animations;
    public TrophyManager trophy;


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
        trophy = FindAnyObjectByType<TrophyManager>();
        health = maxHealth;
    }
    public void Update()
    {
        if (health <= 0)
        {
            win.dood = true;
            animations.monsterDood = true;
            dood = true;
        }
        if (dood && !doodAnimatie)
        {
            doodAnimatie = true;
            animator.SetTrigger("Death");
        }


        if (hitByBomb)
        {
            bombDurationCounter += Time.deltaTime;
            if (bombDurationCounter > bombDuration)
            {
                GetComponentInChildren<SkinnedMeshRenderer>().material = normalMaterial;
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
        hit.isHit = true;
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
        hit.isHit = true;
        health -= Damage;
        monster.UpdateMonsterUI();
    }
}
