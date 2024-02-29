using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    public int scene;
    public void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }
}
