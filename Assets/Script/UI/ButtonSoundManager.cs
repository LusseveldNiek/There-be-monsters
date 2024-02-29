using UnityEngine;

public class ButtonSoundManager : MonoBehaviour
{
    public AudioSource goButtonSound;
    public AudioSource returnButtonSound;

    public void PlayReturnSound()
    {
        returnButtonSound.Play();
    }

    public void PlayGoSound()
    {
        goButtonSound.Play();
    }
}
