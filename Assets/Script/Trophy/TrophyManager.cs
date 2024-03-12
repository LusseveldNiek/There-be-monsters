using UnityEngine;
using UnityEngine.SceneManagement;

public class TrophyManager : MonoBehaviour
{
    public GameObject krakenTrophy;
    public GameObject nessieTrophy;
    public Transform krakenSpawn;
    public Transform nessieSpawn;
    public bool krakenVerslagen;
    public bool krakenGespawnd;
    public bool nessieVerslagen;
    public bool nessieGespwawnd;

    public void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "MainMenu")
        {
            if (krakenVerslagen && !krakenGespawnd)
            {
                Instantiate(krakenTrophy, krakenSpawn);
                krakenGespawnd = true;
            }
            if (nessieVerslagen && !nessieGespwawnd)
            {
                Instantiate(nessieTrophy, nessieSpawn);
                nessieGespwawnd = true;
            }
        }
    }

}
