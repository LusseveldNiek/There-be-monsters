using UnityEngine;

public class WinSpawner : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject head;
    public float spawnDistance = 1.5f;
    public bool dood;
    public int spawns;
    public bool gespawnd;
    private void Start()
    {
        winScreen.SetActive(false);
        head = GameObject.Find("Main Camera");
    }
    void Update()
    {
        if (spawns == 0)
        {
            gespawnd = true;
        }
        else
        {
            gespawnd = false;
        }
        if (dood && gespawnd)
        {
            winScreen.SetActive(true);

            winScreen.transform.position = head.transform.position + new Vector3(head.transform.forward.x, 0, head.transform.forward.z).normalized * spawnDistance;
            spawns = 1;
        }
        winScreen.transform.LookAt(new Vector3(head.transform.position.x, winScreen.transform.position.y, head.transform.position.z));
        winScreen.transform.forward *= -1;

    }
}
