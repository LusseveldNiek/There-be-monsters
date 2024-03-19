using UnityEngine;

public class PlayerHitNessie : MonoBehaviour
{
    public GameOverSpawner gameOver;
    public GameObject controller;
    public NessieAnimations nessieAnimations;
    public GameObject monster;
    
    private void Start()
    {
        controller = GameObject.Find("GameController");
        gameOver = controller.GetComponent<GameOverSpawner>();
        monster = GameObject.Find("Nessie");
        nessieAnimations = monster.GetComponent<NessieAnimations>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            gameOver.dood = true;
            nessieAnimations.dood = true;
        }
    }
}
