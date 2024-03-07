using UnityEngine;

public class CheckIfDouble : MonoBehaviour
{
    public static CheckIfDouble instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
