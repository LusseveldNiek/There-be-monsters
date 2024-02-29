using UnityEngine;

public class BlokMove : MonoBehaviour
{
    public float speed;
    public Vector3 v3;
    public GameObject emptyOnShip;
    private void Start()
    {
        transform.localPosition = Vector3.zero;
        emptyOnShip = GameObject.Find("ShipEmpty");
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, emptyOnShip.transform.position, speed * Time.deltaTime);
        if (transform.position == emptyOnShip.transform.position)
        {
            Destroy(gameObject);
        }
    }
}
