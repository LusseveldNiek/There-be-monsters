using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenAnimations : MonoBehaviour
{
    public Animator anim;
    public bool isPlaying;
    public bool isSwimming;
    private int animatie;
    public float minTime;
    public float maxTime;

    public float timeWaitBlockR;
    public float timeWaitBlockRDone;
    public float timeWaitBlockM;
    public float timeWaitBlockL;
    public float timeWaitBuck;
    public float timeWaitCharge;

    public GameObject blockRIndicator;
    public GameObject blockMIndicator;
    public GameObject blockLIndicator;
    public GameObject buckIndicator;
    public GameObject blockR;
    public GameObject blockM;
    public GameObject blockL;
    public GameObject buck;
    public GameObject bigBlock;

    public AnimatieHit animatieHit;
    public MonsterEscape monsterEscape;
    public MonsterHealth hp;
    public bool dood;
    public bool monsterDood;
    public bool chargeHit;
    public bool passive;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        animatieHit = GetComponent<AnimatieHit>();
        monsterEscape = GetComponent<MonsterEscape>();
        hp = GetComponent<MonsterHealth>();
    }
    IEnumerator WaitForSpawn()
    {
        isPlaying = true;
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        if (!dood && !monsterDood)
        {
            RandomAnimation();
        }
    }
    public void RandomAnimation()
    {
        animatie = Random.Range(1, 8);
        if (animatie == 1)
        {
            Debug.Log("Atc row 1");
            anim.SetTrigger("AttackRow1");
            StartCoroutine(Dodge(timeWaitBlockR, blockRIndicator, blockR));
        }
        if (animatie == 2)
        {
            Debug.Log("Atc row 2");
            anim.SetTrigger("AttackRow2");
            StartCoroutine(Dodge(timeWaitBlockM, blockLIndicator, blockM));
        }
        if (animatie == 3)
        {
            Debug.Log("Atc row 3");
            anim.SetTrigger("AttackRow3");
            StartCoroutine(Dodge(timeWaitBlockL, blockLIndicator, blockL));
        }
        if (animatie == 4)
        {
            Debug.Log("Charge");
            
            anim.SetTrigger("Charge");
            StartCoroutine(Charge(timeWaitCharge));
            animatieHit.inAnimatieCharge = true;
        }
        if (animatie == 5)
        {
            isSwimming = true;
            Debug.Log("Leaving");
            anim.SetTrigger("Leave");
            animatieHit.inAnimatieLeave = true;
            monsterEscape.isEscaping = true;
        }
        if (animatie == 6)
        {
            Debug.Log("Atc hor L");
            anim.SetTrigger("AttackHorizontalL");
            StartCoroutine(Dodge(timeWaitBuck, buckIndicator, buck));
        }
        if (animatie == 7)
        {
            Debug.Log("Atc hor R");
            anim.SetTrigger("AttackHorizontalR");
            StartCoroutine(Dodge(timeWaitBuck, buckIndicator, buck));
        }
    }
    void Update()
    {
        if (!isSwimming && !passive)
        {
            if (isPlaying)
            {
                Debug.Log("return");
                return;
            }
            else
            {
                StartCoroutine(WaitForSpawn());
            }
        }
        if (passive)
        {
            StopAllCoroutines();
        }
    }
    IEnumerator Dodge(float time,GameObject blockIndicator, GameObject block)
    {
        blockIndicator.SetActive(true);
        yield return new WaitForSeconds(time);
        blockIndicator.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        block.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        block.SetActive(false);
        isPlaying = false;
    }
    IEnumerator Charge(float time)
    {
        yield return new WaitForSeconds(time);
        if (!chargeHit)
        {
            bigBlock.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            bigBlock.SetActive(false);
        }
        else
        {
            chargeHit = false;
        }
        isPlaying = false;
    }
}
