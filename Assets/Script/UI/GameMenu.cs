using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenu : MonoBehaviour
{
    public GameObject Menu;
    public InputActionProperty showButton;
    public Transform head;
    public float spawnDistance = 2;
    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            Menu.SetActive(!Menu.activeSelf);

            Menu.transform.position = head.position + new Vector3(head.forward.x, 0 , head.forward.z).normalized * spawnDistance;
        }

        Menu.transform.LookAt(new Vector3(head.position.x, Menu.transform.position.y, head.position.z));
        Menu.transform.forward *= -1;
    }
}
