using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class RotateHarpoen : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    private bool findPrefabRotater;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.onSelectEntered.AddListener(OnGrabbed);

        
    }

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        Debug.Log("Object grabbed!");
        findPrefabRotater = true;
    }

    private void Update()
    {
        if(findPrefabRotater)
        {
            GameObject prefab = GameObject.Find("[Right Controller] Attach");
            prefab.transform.rotation = Quaternion.Euler(116f, 0f, 0f);
            //prefab.transform.localPosition = new Vector3(0.03f, -0.04f, 0f);
            findPrefabRotater = false;

        }
    }
}
