using UnityEngine;

public class CanvasPositioning : MonoBehaviour
{
    public GameObject canvas;
    public bool activateCanvas;
    public GameObject head;
    public float spawnDistance = 1.5f;
    void Update()
    {
        if (activateCanvas)
        {
            canvas.SetActive(true);

            canvas.transform.position = head.transform.position + new Vector3(head.transform.forward.x, 0, head.transform.forward.z).normalized * spawnDistance;
        }
        canvas.transform.LookAt(new Vector3(head.transform.position.x, canvas.transform.position.y, head.transform.position.z));
        canvas.transform.forward *= -1;
    }
}
