using UnityEngine;

public class EscapeSpawner : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject head;
    public float spawnDistance = 1.5f;
    public bool escaped;
    public int spawns;
    public bool gespawnd;
    private void Start()
    {
        gameOver.SetActive(false);
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
        if (escaped && gespawnd)
        {
            gameOver.SetActive(true);

            gameOver.transform.position = head.transform.position + new Vector3(head.transform.forward.x, 0, head.transform.forward.z).normalized * spawnDistance;
            spawns = 1;
        }
        gameOver.transform.LookAt(new Vector3(head.transform.position.x, gameOver.transform.position.y, head.transform.position.z));
        gameOver.transform.forward *= -1;

    }
}
