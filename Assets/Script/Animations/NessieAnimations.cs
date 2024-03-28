using System.Collections;
using UnityEngine;

public class NessieAnimations : MonoBehaviour
{
    public bool isPlaying;
    public bool isSwimming;
    public bool frozen;

    public float freezeDuration;
    private float freezeTime;
    private int animatie;
    public float minTime;
    public float maxTime;
    public float turnTime;
    public bool turn;

    //dodge timers
    public float timeWaitBlockR;
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
    public MonsterTestHP hp;
    public TrophyManager trophy;
    public Animator anim;
    public Hovering hovering;

    public bool dood;
    public bool monsterDood;
    public bool chargeHit;
    public bool passive;
    public Material normalMaterial;

    public AudioSource[] whooshSounds;
    public AudioSource[] waterGunSounds;

    IEnumerator WaitForSpawn()
    {
        animatieHit.isPlaying = true;
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        if (!dood && !monsterDood)
        {
            RandomAnimation();
        }
    }    
    IEnumerator WaitExtra()
    {
        yield return new WaitForSeconds(turnTime);
        StartCoroutine(WaitForSpawn());
    }
    public void RandomAnimation()
    {
        animatie = Random.Range(1, 6);
        if (animatie == 1)
        {
            monsterEscape.isEscaping = false;
            hovering.isAbleToPlay = true;
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
            monsterEscape.isEscaping = false;
            hovering.isAbleToPlay = true;
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
            monsterEscape.isEscaping = false;
            hovering.isAbleToPlay = true;
            Debug.Log("3");
            if (!turn)
            {
                Debug.Log("Atc row 3");
                anim.SetTrigger("AttackRow3");
                StartCoroutine(Dodge(timeWaitBlockL, blockLIndicator, blockL));
            }            
            if (turn)
            {
                Debug.Log("miss");
                StartCoroutine(WaitForSpawn());
            }
        }
        if (animatie == 4)
        {
            Debug.Log("4");
            hovering.isAbleToPlay = false;

            if (turn)
            {
                Debug.Log("Charge");
                anim.SetTrigger("Charge");
                StartCoroutine(Charge(timeWaitCharge));
                animatieHit.inAnimatieCharge = true;
                monsterEscape.isEscaping = false;
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
            monsterEscape.isEscaping = false;
            hovering.isAbleToPlay = true;
            Debug.Log("5");
            if (turn)
            {
                Debug.Log("terug");
                anim.SetBool("Turn", false);
                StartCoroutine(WaitExtra());
                turn = false;
                return;
            }
            if (!turn)
            {
                Debug.Log("turn");
                anim.SetBool("Turn", true);
                StartCoroutine(WaitExtra());
                turn = true;
                return;
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
        if (monsterDood)
        {
            trophy.nessieVerslagen = true;
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
    IEnumerator Dodge(float time, GameObject blockIndicator, GameObject block)
    {
        blockIndicator.SetActive(true);
        if (turn)
        {
            WaterGunSound();
        }
        yield return new WaitForSeconds(time);
        blockIndicator.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        block.SetActive(true);
        if (!turn)
        {
            WhooshSound();
        }
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
        hovering.isAbleToPlay = true;
    }
    void WhooshSound()
    {
        int randomNumber = Random.Range(0, whooshSounds.Length);
        whooshSounds[randomNumber].Play();
    }    
    void WaterGunSound()
    {
        int randomNumber = Random.Range(0, waterGunSounds.Length);
        waterGunSounds[randomNumber].Play();
    }
}
