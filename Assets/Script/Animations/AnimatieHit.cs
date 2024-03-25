using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatieHit : MonoBehaviour
{
    public Animator animator;
    public bool isHit;
    public bool activeHit;
    public float isHitTime = 0.5f;
    private float timer;
    public bool inAnimatieCharge;
    public bool inAnimatieLeave;

    public Swimming monster;


    public bool isSwimming;
    public bool isPlaying;
    public bool isChargeHit;

    
    void Update()
    {
        if (inAnimatieLeave && activeHit)
        {
            animator.SetTrigger("Hurt");
            inAnimatieLeave = false;
            isSwimming = false;
            isPlaying = false;
            monster.escaping = false;
        }
        if (inAnimatieCharge && activeHit)
        {
            animator.SetTrigger("Hurt");
            inAnimatieCharge = false;
            isChargeHit = true;
        }
        if (isHit)
        {
            timer = isHitTime;
            activeHit = true;
            isHit = false;
        }
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            activeHit = false;
        }
    }
}
