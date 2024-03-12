using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public GameOverSpawner gameOver;
    public GameObject controller;
    public KrakenAnimations krakenAnimations;
    public GameObject kraken;
    private void Start()
    {
        controller = GameObject.Find("GameController");
        gameOver = controller.GetComponent<GameOverSpawner>();
        kraken = GameObject.Find("Kraken");
        krakenAnimations = kraken.GetComponent<KrakenAnimations>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            gameOver.dood = true;
            krakenAnimations.dood = true;
        }
    }
}
