using TMPro;
using UnityEngine;

public class DefToolNessie : MonoBehaviour
{
    public TextMeshProUGUI nummerText;
    public Animator anim;
    public GameObject animationCanvas;
    public NessieAnimations nessie;
    public int animatieNummer;
    public int maxAnimations;
    public bool swimming;
    public bool passive;
    public bool turn;
    // Start is called before the first frame update
    void Start()
    {
        animatieNummer = 1;
        nummerText.text = "Animation " + animatieNummer.ToString() + "/" + maxAnimations.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        turn = nessie.turn;
        passive = nessie.passive;
        if (animatieNummer > maxAnimations)
        {
            animatieNummer = 1;
            ReloadUI();
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (!passive)
            {
                animationCanvas.SetActive(true);
                Debug.Log("passive");
                nessie.passive = true;
            }
            if (passive)
            {
                animationCanvas.SetActive(false);
                Debug.Log("attack");
                nessie.passive = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            if (!turn)
            {
                Debug.Log("Atc hor R");
                anim.SetBool("Turn", true);
                nessie.turn = true;
            }      
            if (turn)
            {
                Debug.Log("Atc hor R");
                anim.SetBool("Turn", false);
                nessie.turn = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
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
        animatieNummer++;
        ReloadUI();
    }
    public void ReloadUI()
    {
        nummerText.text = "Animation " + animatieNummer.ToString() + "/" + maxAnimations.ToString();
    }
    void Play()
    {
        if (animatieNummer == 1)
        {
            Debug.Log("1");
            if (!turn)
            {
                Debug.Log("Atc row 1");
                anim.SetTrigger("AttackRow1");
            }
            if (turn)
            {
                Debug.Log("Atc hor L");
                anim.SetTrigger("AttackHorizontalL");
            }
        }
        if (animatieNummer == 2)
        {
            Debug.Log("2");
            if (!turn)
            {
                Debug.Log("Atc row 2");
                anim.SetTrigger("AttackRow2");
            }
            if (turn)
            {
                Debug.Log("Atc hor R");
                anim.SetTrigger("AttackHorizontalR");
            }
        }
        if (animatieNummer == 3)
        {
            Debug.Log("3");
            if (!turn)
            {
                Debug.Log("Atc row 3");
                anim.SetTrigger("AttackRow3");
            }
            if (turn)
            {
                Debug.Log("miss");
            }
        }
        if (animatieNummer == 4)
        {
            Debug.Log("4");
            if (turn)
            {
                Debug.Log("Charge");
                anim.SetTrigger("Charge");
            }
            if (!turn)
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
        }
    }
}
