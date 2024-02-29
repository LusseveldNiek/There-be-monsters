using UnityEngine;

public class GameOverSpawner : MonoBehaviour
{
    public GameObject gameOver;
    public Transform head;
    public float spawnDistance = 1.5f;
    public bool dood;
    public int spawns;
    public bool gespawnd;
    private void Start()
    {
        gameOver.SetActive(false);
        Time.timeScale = 1;
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
            gameOver.SetActive(true);

            gameOver.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
            spawns = 1;
        }
        gameOver.transform.LookAt(new Vector3(head.position.x, gameOver.transform.position.y, head.position.z));
        gameOver.transform.forward *= -1;

    }
}
