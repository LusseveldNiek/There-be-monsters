using UnityEngine;

public class DefToolAnimations : MonoBehaviour
{
    public Animator anim;
    public GameObject animationCanvas;
    public KrakenAnimations kraken;
    public DefToolCanvasAnimations canvas;
    public bool passive;
    public bool swimming;
    public int animationNummer;

    // Update is called once per frame
    void Update()
    {
        animationNummer = canvas.animationNummer;
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            kraken.passive = true;
            animationCanvas.SetActive(true);
            passive = true;
            Debug.Log("passive");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            kraken.passive = false;
            animationCanvas.SetActive(false);
            passive = false;
            Debug.Log("attack mode");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            if (passive)
            {
                animationNummer++;
                canvas.NextNummer();
                Debug.Log("up");
            }
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            if (passive) 
            { 
                Play();
                Debug.Log("play");
            }
        }
    }
    void Play()
    {
        if (animationNummer == 1)
        {
            Debug.Log("Atc row 1");
            anim.SetTrigger("AttackRow1");
        }
        if (animationNummer == 2)
        {
            Debug.Log("Atc row 2");
            anim.SetTrigger("AttackRow2");
        }
        if (animationNummer == 3)
        {
            Debug.Log("Atc row 3");
            anim.SetTrigger("AttackRow3");
        }
        if (animationNummer == 4)
        {
            Debug.Log("Charge");
            anim.SetTrigger("Charge");
        }
        if (animationNummer == 5)
        {
            if (!swimming)
            {
                Debug.Log("Leaving");
                anim.SetTrigger("Leave");
                swimming = true;
                return;
            }
            if (swimming)
            {
                Debug.Log("hit");
                anim.SetTrigger("Hurt");
                swimming = false;
                return;
            }
        }
        if (animationNummer == 6)
        {
            Debug.Log("Atc hor L");
            anim.SetTrigger("AttackHorizontalL");
        }
        if (animationNummer == 7)
        {
            Debug.Log("Atc hor R");
            anim.SetTrigger("AttackHorizontalR");
        }        
        if (animationNummer == 8)
        {
            Debug.Log("Atc hor R");
            anim.SetBool("Death", true);
        }
    }
}
