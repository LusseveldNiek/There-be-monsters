using UnityEngine;

public class BlokTrigger : MonoBehaviour
{
    public PlacerSpawn trigger;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            trigger.SpawnNext();
        }
    }
}