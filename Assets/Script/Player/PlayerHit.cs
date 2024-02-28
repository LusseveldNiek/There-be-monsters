using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public GameOverSpawner gameOver;
    public GameObject controller;
    private void Start()
    {
        controller = GameObject.Find("GameController");
        gameOver = controller.GetComponent<GameOverSpawner>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            gameOver.dood = true;
        }
    }
}
