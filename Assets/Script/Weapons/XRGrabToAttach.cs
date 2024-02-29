using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabToAttach : XRGrabInteractable
{
    public Transform leftHand;
    public Transform rightHand;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag("LeftHand"))
        {
            attachTransform = leftHand;
        }

        base.OnSelectEntered(args);
    }
}
