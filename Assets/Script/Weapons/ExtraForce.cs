using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ExtraForce : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public float enoughSpeed;
    public float power;
    private bool thrown;
    public bool goodSpeed;
    public Rigidbody rb;

    [System.Obsolete]
    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectExited.AddListener(OnRelease);
        rb = GetComponent<Rigidbody>();
    }
    public void OnRelease(XRBaseInteractor interactor)
    {
        Debug.Log("Object thrown!");
        thrown = true;
    }
    
    public void Update()
    {
        if (thrown && goodSpeed)
        {
            Vector3 lookat = transform.position + rb.velocity;
            transform.LookAt(lookat);
        }
        if (thrown)
        {
            rb.AddForce(transform.forward * power);
        }
        if (rb.velocity.magnitude >= enoughSpeed)
        {
            goodSpeed = true;
        }
        else
        {
            goodSpeed = false;
        }
    }
}
