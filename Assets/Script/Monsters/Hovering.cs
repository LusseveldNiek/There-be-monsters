using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hovering : MonoBehaviour
{
    public float hoverSpeed;
    public float hoverDistance;

    private Vector3 startPosition;

    public bool isAbleToPlay; //disables when escaping

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if(isAbleToPlay)
        {
            float xNoise = Mathf.PerlinNoise(Time.time * hoverSpeed, 0) - 0.5f;
            float yNoise = Mathf.PerlinNoise(0, Time.time * hoverSpeed) - 0.5f;
            float zNoise = Mathf.PerlinNoise(Time.time * hoverSpeed, Time.time * hoverSpeed) - 0.5f;

            Vector3 targetPosition = startPosition + new Vector3(xNoise, yNoise, zNoise) * hoverDistance;

            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * hoverSpeed);
        }
    }
}
