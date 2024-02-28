using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LazerActivate : MonoBehaviour
{
    XRRayInteractor interactor;
    private void Start()
    {
        interactor = GetComponent<XRRayInteractor>();
    }
    private void Update()
    {
        if (interactor.IsOverUIGameObject())
        {
            GetComponent<XRInteractorLineVisual>().enabled = true;
            GetComponent<LineRenderer>().enabled = true;
        }
        else
        {
            GetComponent<XRInteractorLineVisual>().enabled = false;
            GetComponent <LineRenderer>().enabled = false;
        }
    }
}
