using System.Collections;
using UnityEngine;

public class KrakenAnimations : MonoBehaviour
{
    public bool isPlaying;
    public bool isSwimming;
    public bool chargeHit;

    public bool frozen;
    private int animatie;
    public float minTime;
    public float maxTime;

    //dodge timers
    public float timeWaitBlockR;
    public float timeWaitBlockRDone;
    public float timeWaitBlockM;
    public float timeWaitBlockL;
    public float timeWaitBuck;
    public float timeWaitCharge;

    //dodge prefabs
    public GameObject blockRIndicator;
    public GameObject blockMIndicator;
    public GameObject blockLIndicator;
    public GameObject buckIndicator;
    public GameObject blockR;
    public GameObject blockM;
    public GameObject blockL;
    public GameObject buck;
    public GameObject bigBlock;

    //scripts
    public AnimatieHit animatieHit;
    public MonsterEscape monsterEscape;
    public MonsterTestHP monsterHealth;
    public Animator anim;

    public bool dood;
    public bool monsterDood;
    public bool passive;
    public Material normalMaterial;

    //sounds
    public AudioSource[] whooshSounds;

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
            StartCoroutine(Dodge(timeWaitBlockM, blockMIndicator, blockM));
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
            animatieHit.isSwimming = true;
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

        //sounds
        int randomNumber = Random.Range(0, 4);
        whooshSounds[randomNumber].Play();

    }

    void Update()
    {
        //animation script kijkt van de animatieScript af, zodat er geen 2 verschillende animatieHit scripts hoeven te zijn
        isPlaying = animatieHit.isPlaying;
        isSwimming = animatieHit.isSwimming;
        chargeHit = animatieHit.isChargeHit;

        monsterDood = monsterHealth.monsterDood;

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
            frozen = false;
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
            animatieHit.isChargeHit = false;
        }
        isPlaying = false;
    }
}
