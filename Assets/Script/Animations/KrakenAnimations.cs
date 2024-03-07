using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenAnimations : MonoBehaviour
{
    public Animator anim;
    public bool isPlaying;
    private int animatie;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    IEnumerator WaitForSpawn()
    {
        isPlaying = true;
        yield return new WaitForSeconds(Random.Range(10, 20));
        RandomAnimation();
        isPlaying = false;
    }
    public void RandomAnimation()
    {
        animatie = Random.Range(1, 7);
        if (animatie == 1)
        {
            Debug.Log("1");
        }
        if (animatie == 2)
        {
            Debug.Log("2");
        }
        if (animatie == 3)
        {
            Debug.Log("3");
        }
        if (animatie == 4)
        {
            Debug.Log("4");
        }
        if (animatie == 5)
        {
            Debug.Log("5");
        }
        if (animatie == 6)
        {
            Debug.Log("6");
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
