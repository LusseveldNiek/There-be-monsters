using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenu : MonoBehaviour
{
    public GameObject Menu;
    public InputActionProperty showButton;
    public GameObject head;
    public float spawnDistance = 2;
    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
        head = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            Menu.SetActive(!Menu.activeSelf);

            Menu.transform.position = head.transform.position + new Vector3(head.transform.forward.x, 0 , head.transform.forward.z).normalized * spawnDistance;
        }

        Menu.transform.LookAt(new Vector3(head.transform.position.x, Menu.transform.position.y, head.transform.position.z));
        Menu.transform.forward *= -1;
    }
}
