using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HarpoenSpawn : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public Weapon weapon;
    public float fast;
    public bool grabbed;
    public bool spawned;

    [System.Obsolete]
    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnGrabbed);
        weapon = GetComponent<Weapon>();
    }

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        Debug.Log("Object grabbed!");
        weapon.SpawnHarpoon();
        Destroy(this);
    }
}
