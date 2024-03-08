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
        }
        if (animatie == 2)
        {
            Debug.Log("Atc row 2");
            anim.SetTrigger("AttackRow2");
        }
        if (animatie == 3)
        {
            Debug.Log("Atc row 3");
            anim.SetTrigger("AttackRow1");
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
        }
        if (animatie == 7)
        {
            Debug.Log("Atc hor R");
            anim.SetTrigger("AttackHorizontalR");
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
}
