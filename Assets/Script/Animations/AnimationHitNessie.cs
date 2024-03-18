using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHitNessie : MonoBehaviour
{
    public Animator animator;
    public bool isHit;
    private bool activeHit;
    public float isHitTime = 0.5f;
    private float timer;
    public bool inAnimatieCharge;
    public bool inAnimatieLeave;

    public NessieAnimations animations;
    public MonsterEscape monster;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animations = GetComponent<NessieAnimations>();
        monster = GetComponent<MonsterEscape>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inAnimatieLeave && activeHit)
        {
            animator.SetTrigger("Hurt");
            inAnimatieLeave = false;
            animations.isSwimming = false;
            animations.isPlaying = false;
            monster.isEscaping = false;
        }
        if (inAnimatieCharge && activeHit)
        {
            animator.SetTrigger("Hurt");
            inAnimatieCharge = false;
            animations.chargeHit = true;
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
