using UnityEngine;

public class TrothySpawner : MonoBehaviour
{
    public GameObject krakenTrophy;
    public GameObject nessieTrophy;
    public bool krakenVerslagen;
    public bool krakenGespawnd;
    public bool nessieVerslagen;
    public bool nessieGespwawnd;

    public TrophyManager TrophyManager;

    private void Start()
    {
        TrophyManager = FindAnyObjectByType<TrophyManager>();
    }
    public void Update()
    {
        krakenVerslagen = TrophyManager.krakenVerslagen;
        nessieVerslagen = TrophyManager.nessieVerslagen;
        if (krakenVerslagen && !krakenGespawnd)
        {
            krakenTrophy.SetActive(true);
            krakenGespawnd = true;
        }
        if (nessieVerslagen && !nessieGespwawnd)
        {
            nessieTrophy.SetActive(true);
            nessieGespwawnd = true;
        }
        TrophyManager = FindAnyObjectByType<TrophyManager>();
    }
}
