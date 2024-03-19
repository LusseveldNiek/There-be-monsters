using System.Collections;
using UnityEngine;

public class NessieAnimations : MonoBehaviour
{
    public Animator anim;
    public bool isPlaying;
    public bool isSwimming;
    public bool frozen;
    public float freezeDuration;
    private float freezeTime;
    private int animatie;
    public float minTime;
    public float maxTime;
    public bool turn;

    public float timeWaitBlockR;
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
    public MonsterTestHP hp;
    public bool dood;
    public bool monsterDood;
    public bool chargeHit;
    public bool passive;
    public Material normalMaterial;

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
        animatie = Random.Range(1, 6);
        if (animatie == 1)
        {
            Debug.Log("1");
            if (!turn)
            {
                Debug.Log("Atc row 1");
                anim.SetTrigger("AttackRow1");
                StartCoroutine(Dodge(timeWaitBlockR, blockRIndicator, blockR));
            }
            if (turn)
            {
                Debug.Log("Atc hor L");
                anim.SetTrigger("AttackHorizontalL");
                StartCoroutine(Dodge(timeWaitBuck, buckIndicator, buck));
            }
        }
        if (animatie == 2)
        {
            Debug.Log("2");
            if (!turn)
            {
                Debug.Log("Atc row 2");
                anim.SetTrigger("AttackRow2");
                StartCoroutine(Dodge(timeWaitBlockM, blockMIndicator, blockM));
            }
            if (turn)
            {
                Debug.Log("Atc hor R");
                anim.SetTrigger("AttackHorizontalR");
                StartCoroutine(Dodge(timeWaitBuck, buckIndicator, buck));
            }
        }
        if (animatie == 3)
        {
            Debug.Log("3");
            if (!turn)
            {
                Debug.Log("Atc row 3");
                anim.SetTrigger("AttackRow3");
                StartCoroutine(Dodge(timeWaitBlockL, blockLIndicator, blockL));
            }
        }
        if (animatie == 4)
        {
            Debug.Log("4");
            if (turn)
            {
                Debug.Log("Charge");
                anim.SetTrigger("Charge");
                StartCoroutine(Charge(timeWaitCharge));
                animatieHit.inAnimatieCharge = true;
            }
            if (!turn)
            {
                animatieHit.isSwimming = true;
                Debug.Log("Leaving");
                anim.SetTrigger("Leave");
                animatieHit.inAnimatieLeave = true;
                monsterEscape.isEscaping = true;
            }
        }
        if (animatie == 5)
        {
            Debug.Log("5");
            if (turn)
            {
                turn = false;
                anim.SetBool("Turn", turn);
                StartCoroutine(WaitForSpawn());
            }
            if (!turn)
            {
                turn = true;
                anim.SetBool("Turn", turn);
                StartCoroutine(WaitForSpawn());
            }
        }
    }
    void Update()
    {
        //animation script kijkt van de animatieScript af, zodat er geen 2 verschillende animatieHit scripts hoeven te zijn
        isPlaying = animatieHit.isPlaying;
        isSwimming = animatieHit.isSwimming;
        chargeHit = animatieHit.isChargeHit;

        monsterDood = hp.monsterDood;

        if (!isSwimming && !passive && !frozen)
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
            animatieHit.isPlaying = false;
        }
        if (frozen)
        {
            StopAllCoroutines();
        }
        if (frozen)
        {
            freezeTime += Time.deltaTime;
            Debug.Log("aftellen");
            if (freezeTime > freezeDuration)
            {
                GetComponentInChildren<SkinnedMeshRenderer>().material = normalMaterial;
                freezeTime = 0;
                frozen = false;
                Debug.Log("unfreeze");
            }
        }
    }
    IEnumerator Dodge(float time, GameObject blockIndicator, GameObject block)
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
            animatieHit.isChargeHit = false;
        }
        isPlaying = false;
    }
}
