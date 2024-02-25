using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    Animator animator;
    public float health = 200;
    public int DMGMultiplier = 3;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void NormalDamage(float Damage)
    {
        health -= Damage;
        print("hit");
    }
    public void CritHit(float Damage)
    {
        health -= DMGMultiplier * Damage;
        print("crit");
    }
    void Update()
    {
        
    }
}
