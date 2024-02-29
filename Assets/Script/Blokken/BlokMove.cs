using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, emptyOnShip.transform.position, speed * Time.deltaTime);

        // Optionally, you can check if the object has reached the target position
        if (transform.position == emptyOnShip.transform.position)
        {
            // Object has reached the target position, you can perform any additional actions here
            Destroy(gameObject);
        }
    }
}
