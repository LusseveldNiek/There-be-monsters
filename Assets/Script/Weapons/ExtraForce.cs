using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ExtraForce : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public GameObject lookAtPoint;
    private bool thrown;
    public Rigidbody rb;

    [System.Obsolete]
    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectExited.AddListener(OnRelease);
        rb = GetComponent<Rigidbody>();
        lookAtPoint = GameObject.Find("KijkpuntHarpoen");
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
            Vector3 lookat = transform.position + rb.velocity;
            transform.LookAt(lookat);
        }
    }
}
