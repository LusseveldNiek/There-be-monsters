using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenAnimations : MonoBehaviour
{
    public Animator anim;
    public bool isPlaying;
    private int animatie;
    public float minTime;
    public float maxTime;

    public float timeWaitBlockR;
    public float timeWaitBlockRDone;
    public float timeWaitBlockM;
    public float timeWaitBlockL;
    public float timeWaitBuck;

    public GameObject blockRIndicator;
    public GameObject blockMIndicator;
    public GameObject blockLIndicator;
    public GameObject buckIndicator;
    public GameObject blockR;
    public GameObject blockM;
    public GameObject blockL;
    public GameObject buck;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    IEnumerator WaitForSpawn()
    {
        isPlaying = true;
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        RandomAnimation();
        isPlaying = false;
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
        }
        if (animatie == 5)
        {
            Debug.Log("Leaving");
            anim.SetTrigger("Leave");
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
        if (isPlaying)
        {
            return;
        }
        else
        {
            StartCoroutine(WaitForSpawn());
        }
    }
    IEnumerator BlockR(float time)
    {
        blockRIndicator.SetActive(true);
        yield return new WaitForSeconds(time);
        blockRIndicator.SetActive(false);
        yield return new WaitForSeconds(0.5f);
    }
    IEnumerator BlockM(float time)
    {
        blockMIndicator.SetActive(true);
        yield return new WaitForSeconds(time);
        blockMIndicator.SetActive(false);
        yield return new WaitForSeconds(0.5f);
    }
    IEnumerator BlockL(float time)
    {
        blockLIndicator.SetActive(true);
        yield return new WaitForSeconds(time);
        blockLIndicator.SetActive(false);
        yield return new WaitForSeconds(0.5f);

    }
    IEnumerator Buck(float time)
    {
        buckIndicator.SetActive(true);
        yield return new WaitForSeconds(time);
        buckIndicator.SetActive(false);
        yield return new WaitForSeconds(0.5f);
    }
}
