using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSpawner : MonoBehaviour
{
    public GameObject gameOver;
    public Transform head;
    public float spawnDistance = 1.5f;
    public bool dood;
    private void Start()
    {
        gameOver.SetActive(false);
    }
    void Update()
    {
        if (dood)
        {
            gameOver.SetActive(true);

            gameOver.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        }

        gameOver.transform.LookAt(new Vector3(head.position.x, gameOver.transform.position.y, head.position.z));
        gameOver.transform.forward *= -1;
    }
}
