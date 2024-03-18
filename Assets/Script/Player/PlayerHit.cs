using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public GameOverSpawner gameOver;
    public GameObject controller;
    public KrakenAnimations krakenAnimations;
    public GameObject monster;
    
    private void Start()
    {
        controller = GameObject.Find("GameController");
        gameOver = controller.GetComponent<GameOverSpawner>();
        monster = GameObject.Find("Kraken");
        krakenAnimations = monster.GetComponent<KrakenAnimations>();
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
