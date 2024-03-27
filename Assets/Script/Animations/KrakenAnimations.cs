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
    public TrophyManager trophy;
    public Animator anim;
    public Swimming swimming;
    public Hovering hovering;

    public bool dood;
    public bool monsterDood;
    public bool passive;
    public Material normalMaterial;

    //sounds
    public AudioSource[] whooshSounds;

    IEnumerator WaitForSpawn()
    {
        animatieHit.isPlaying = true;
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        if (!dood && !monsterDood)
        {
            RandomAnimation();
            print("werkt");
        }
    }
    public void RandomAnimation()
    {
        animatie = Random.Range(5, 5);
        if (animatie == 1)
        {
            //Debug.Log("Atc row 1");
            anim.SetTrigger("AttackRow1");
            StartCoroutine(Dodge(timeWaitBlockR, blockRIndicator, blockR));

            hovering.isAbleToPlay = true;
        }
        if (animatie == 2)
        {
            //Debug.Log("Atc row 2");
            anim.SetTrigger("AttackRow2");
            StartCoroutine(Dodge(timeWaitBlockM, blockMIndicator, blockM));

            hovering.isAbleToPlay = true;
        }
        if (animatie == 3)
        {
            //Debug.Log("Atc row 3");
            anim.SetTrigger("AttackRow3");
            StartCoroutine(Dodge(timeWaitBlockL, blockLIndicator, blockL));

            hovering.isAbleToPlay = true;
        }
        if (animatie == 4)
        {
            //Debug.Log("Charge");
            
            anim.SetTrigger("Charge");
            StartCoroutine(Charge(timeWaitCharge));
            animatieHit.inAnimatieCharge = true;

            hovering.isAbleToPlay = true;
        }
        if (animatie == 5)
        {
            animatieHit.isSwimming = true;
            anim.SetTrigger("Leave");
            animatieHit.inAnimatieLeave = true;
            swimming.escaping = true;
            hovering.isAbleToPlay = false;

            print("leave");
        }
        if (animatie == 6)
        {
            //Debug.Log("Atc hor L");
            anim.SetTrigger("AttackHorizontalL");
            StartCoroutine(Dodge(timeWaitBuck, buckIndicator, buck));

            hovering.isAbleToPlay = true;
        }
        if (animatie == 7)
        {
            //Debug.Log("Atc hor R");
            anim.SetTrigger("AttackHorizontalR");
            StartCoroutine(Dodge(timeWaitBuck, buckIndicator, buck));

            hovering.isAbleToPlay = true;
        }

    }

    void Update()
    {
        //animation script kijkt van de animatieScript af, zodat er geen 2 verschillende animatieHit scripts hoeven te zijn
        isPlaying = animatieHit.isPlaying;
        isSwimming = animatieHit.isSwimming;
        chargeHit = animatieHit.isChargeHit;

        monsterDood = monsterHealth.monsterDood;

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
        if (monsterDood)
        {
            trophy.krakenVerslagen = true;
        }
        if (!isSwimming && !passive && !frozen)
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
    IEnumerator Dodge(float time,GameObject blockIndicator, GameObject block)
    {
        blockIndicator.SetActive(true);
        yield return new WaitForSeconds(time);
        blockIndicator.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        //sounds
        int randomNumber = Random.Range(0, whooshSounds.Length);
        whooshSounds[randomNumber].Play();

        block.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        block.SetActive(false);
        animatieHit.isPlaying = false;
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
        animatieHit.isPlaying = false;
    }
    private void Start()
    {
        trophy = FindAnyObjectByType<TrophyManager>();
    }
}
