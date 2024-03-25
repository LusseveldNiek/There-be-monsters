using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameOverSpawner : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject head;
    public float spawnDistance = 1.5f;
    public bool dood;
    public int spawns;
    public bool gespawnd;

    public GameObject[] playerHandRays;
    private void Start()
    {
        gameOver.SetActive(false);
        head = GameObject.Find("Main Camera");

        //disable raycasts in player hands to grab objects normaly
        for (int i = 0; i < playerHandRays.Length; i++)
        {
            playerHandRays[i].SetActive(false);
        }
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

            //disable all grab interactables
            XRGrabInteractable[] grabInteractables = FindObjectsOfType<XRGrabInteractable>();
            for (int i = 0; i < grabInteractables.Length; i++)
            {
                grabInteractables[i].enabled = false;
            }



            gameOver.transform.position = head.transform.position + new Vector3(head.transform.forward.x, 0, head.transform.forward.z).normalized * spawnDistance;
            spawns = 1;

            //enable player raycasts to interact with UI
            for (int i = 0; i < playerHandRays.Length; i++)
            {
                playerHandRays[i].SetActive(true);
            }
        }
        gameOver.transform.LookAt(new Vector3(head.transform.position.x, gameOver.transform.position.y, head.transform.position.z));
        gameOver.transform.forward *= -1;

    }
}
