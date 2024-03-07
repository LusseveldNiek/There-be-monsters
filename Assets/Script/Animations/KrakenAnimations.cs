using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenAnimations : MonoBehaviour
{
    public Animator anim;
    private int animatie;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    IEnumerator WaitForSpawn()
    {
        yield return new WaitForSeconds(Random.Range(5, 10));
        RandomAnimation();
    }
    public void RandomAnimation()
    {
        animatie = Random.Range(1, 8);
        if (animatie == 1)
        {
          //  anim.Play();
        }
        if (animatie == 2)
        {

        }
        if (animatie == 3)
        {

        }
        if (animatie == 4)
        {

        }
        if (animatie == 5)
        {

        }
        if (animatie == 6)
        {

        }
    }
    void Update()
    {
        if (anim.isActiveAndEnabled)
        {
            return;
        }
        else
        {
            RandomAnimation();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Spinning");
            anim.Play("spin");
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Jumping");
            anim.Play("jump");
        }

        // combine jump and spin
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jumping and spinning");
            anim.Play("jump");
            anim.Play("spin");
        }

        // have spin speed reverted to 1.0 second
        //if (fastSpin == true)
        {
          //  anim["spin"].speed = 1.0f;
           // fastSpin = false;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Jumping and spinning in half a second");
            anim.Play("jump");
          //  anim["spin"].speed = 2.0f;
            anim.Play("spin");

            // we've used spin at a speed of two, now mark
            // the spin speed to revert back to one
         //   fastSpin = true;
        }
    }
}
