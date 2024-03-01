using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ExtraForce : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public RotateHarpoen rotateHarpoen;
    public GameObject lookAtPoint;
    private bool thrown;
    public float power;
    public Rigidbody rb;

    [System.Obsolete]
    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rotateHarpoen = GetComponent<RotateHarpoen>();
        grabInteractable.onSelectExited.AddListener(OnRelease);
        thrown = rotateHarpoen.findPrefabRotater;
        rb = GetComponent<Rigidbody>();
        lookAtPoint = GameObject.Find("SpawnLocationBlokken");
    }
    public void OnRelease(XRBaseInteractor interactor)
    {
        Debug.Log("Object thrown!");
        thrown = true;
    }
    
    public void Update()
    {
        if (thrown)
        {
            rb.AddForce(transform.forward * power);
            transform.LookAt(lookAtPoint.transform.position);
        }
    }
}
