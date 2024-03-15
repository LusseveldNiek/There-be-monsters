using TMPro;
using UnityEngine;

public class DefToolNessie : MonoBehaviour
{
    public TextMeshProUGUI nummerText;
    public int animationNummer;
    // Start is called before the first frame update
    void Start()
    {
        animationNummer = 1;
        nummerText.text = "Animation " + animationNummer.ToString() + "/10";
    }

    // Update is called once per frame
    void Update()
    {
        if (animationNummer >= 9)
        {
            animationNummer = 1;
            ReloadUI();
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
}
