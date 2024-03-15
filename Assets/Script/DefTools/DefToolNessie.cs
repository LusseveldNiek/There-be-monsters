using TMPro;
using UnityEngine;

public class DefToolNessie : MonoBehaviour
{
    public TextMeshProUGUI nummerText;
    public Animator anim;
    public GameObject monster;
    public GameObject animationCanvas;
    public int animationNummer;
    public bool passive;
    public bool turn;
    // Start is called before the first frame update
    void Start()
    {
        animationNummer = 1;
        nummerText.text = "Animation " + animationNummer.ToString() + "/6";
    }

    // Update is called once per frame
    void Update()
    {
        if (animationNummer >= 7)
        {
            animationNummer = 1;
            ReloadUI();
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            animationCanvas.SetActive(true);
            Debug.Log("passive");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            if (!turn)
            {
                Debug.Log("Atc hor R");
                turn = true;
                anim.SetBool("Turn", turn);
            }      
            if (turn)
            {
                Debug.Log("Atc hor R");
                turn = false;
                anim.SetBool("Turn", turn);
            }
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            animationNummer++;
            NextNummer();
            Debug.Log("up");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            Play();
            Debug.Log("play");
        }
    }
    public void NextNummer()
    {
        animationNummer++;
        ReloadUI();
    }
    public void ReloadUI()
    {
        nummerText.text = "Animation " + animationNummer.ToString() + "/8";
    }
    void Play()
    {
        if (animationNummer == 1)
        {
            Debug.Log("Atc row 1");
            anim.SetTrigger("AtcRow1");
        }
        if (animationNummer == 2)
        {
            Debug.Log("Atc row 2");
            anim.SetTrigger("AtcRow2");
        }
        if (animationNummer == 3)
        {
            Debug.Log("Atc row 3");
            anim.SetTrigger("AtcRow3");
        }
        if (animationNummer == 4)
        {
            Debug.Log("Charge");
            anim.SetTrigger("Charge");
        }
        if (animationNummer == 5)
        {
            Debug.Log("Leaving");
            anim.SetTrigger("Leave");
        }
        if (animationNummer == 6)
        {
            Debug.Log("Death");
            anim.SetBool("Death", true);
        }
    }
}
