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
            isPlaying = false;
        }
    }
    public void RandomAnimation()
    {
        animatie = Random.Range(1, 8);
        if (animatie == 1)
        {
            Debug.Log("Atc row 1");
            anim.SetTrigger("AttackRow1");
            StartCoroutine(BlockR(timeWaitBlockR));
        }
        if (animatie == 2)
        {
            Debug.Log("Atc row 2");
            anim.SetTrigger("AttackRow2");
            StartCoroutine(BlockM(timeWaitBlockM));
        }
        if (animatie == 3)
        {
            Debug.Log("Atc row 3");
            anim.SetTrigger("AttackRow3");
            StartCoroutine(BlockL(timeWaitBlockL));
        }
        if (animatie == 4)
        {
            Debug.Log("Charge");
            
            anim.SetTrigger("Charge");
            StartCoroutine(Charge(timeWaitBlockL));
            animatieHit.inAnimatieCharge = true;
        }
        if (animatie == 5 && monsterEscape.isEscaping == false)
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
            StartCoroutine(Buck(timeWaitBuck));
        }
        if (animatie == 7)
        {
            Debug.Log("Atc hor R");
            anim.SetTrigger("AttackHorizontalR");
            StartCoroutine(Buck(timeWaitBuck));
        }
    }
    void Update()
    {
        if (!isSwimming)
        {
            if (isPlaying)
            {
                return;
            }
            else
            {
                StartCoroutine(WaitForSpawn());
            }
        }
    }

    IEnumerator BlockR(float time)
    {
        blockRIndicator.SetActive(true);
        yield return new WaitForSeconds(time);
        blockRIndicator.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        blockR.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        blockR.SetActive(false);
    }
    IEnumerator BlockM(float time)
    {
        blockMIndicator.SetActive(true);
        yield return new WaitForSeconds(time);
        blockMIndicator.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        blockM.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        blockM.SetActive(false);
    }
    IEnumerator BlockL(float time)
    {
        blockLIndicator.SetActive(true);
        yield return new WaitForSeconds(time);
        blockLIndicator.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        blockL.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        blockL.SetActive(false);
    }
    IEnumerator Buck(float time)
    {
        buckIndicator.SetActive(true);
        yield return new WaitForSeconds(time);
        buckIndicator.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        buck.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        buck.SetActive(false);
    }
    IEnumerator Charge(float time)
    {
        buckIndicator.SetActive(true);
        yield return new WaitForSeconds(time);
        buckIndicator.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        if (!chargeHit)
        {
            blockL.SetActive(true);
            blockM.SetActive(true);
            blockR.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            blockL.SetActive(false);
            blockM.SetActive(false);
            blockR.SetActive(false);
        }
        else
        {
            chargeHit = false;
        }
    }
}
