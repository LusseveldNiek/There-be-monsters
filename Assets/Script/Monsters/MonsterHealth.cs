using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    Animator animator;
    public MonsterUI monster;
    public int health = 200;
    public int maxHealth = 200;
    public int DMGMultiplier = 3;

    public GameObject WinScreen;
    public GameObject head;
    public float spawnDistance = 1.5f;
    public int spawns = 0;
    public bool dood;
    public bool gespawnd;


    [Header("Bomb")]
    
    //if hit by bomb
    public bool hitByBomb;
    //amount of damage
    public int bombDamage;
    //duration bomb effect
    private float bombDurationCounter;
    public float bombDuration;
    //change material monster back to normal
    public Material normalMaterial;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        monster = GetComponent<MonsterUI>();
        head = GameObject.Find("Main Camera");
        health = maxHealth;
    }

    private void Update()
    {
        if (health <= 0)
        {
            dood = true;
        }
        if (spawns == 0)
        {
            gespawnd = true;
        }
        else
        {
            gespawnd = false;
        }
        if (dood && gespawnd)
        {
            WinScreen.SetActive(true);

            WinScreen.transform.position = head.transform.position + new Vector3(head.transform.forward.x, 0, head.transform.forward.z).normalized * spawnDistance;
            spawns = 1;
        }
        WinScreen.transform.LookAt(new Vector3(head.transform.position.x, WinScreen.transform.position.y, head.transform.position.z));
        WinScreen.transform.forward *= -1;

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
        Damage = DMGMultiplier * Damage;

        if (hitByBomb)
        {
            Damage += bombDamage;
        }

        health -= Damage;

        monster.UpdateMonsterUI();
    }
}
