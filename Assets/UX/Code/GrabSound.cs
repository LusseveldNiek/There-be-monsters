using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabSound : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public AudioSource grabSoundEffect;

    [System.Obsolete]

    private void Start()
    {
        grabInteractable.onSelectEntered.AddListener(OnGrabbed);
    }

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        Debug.Log("Object grabbed!");
        grabSoundEffect.Play();
    }
}
