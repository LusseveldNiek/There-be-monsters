using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlokMove : MonoBehaviour
{
    public float speed;
    public Vector3 v3;
    void Update()
    {
        transform.Translate(v3 + -transform.forward * speed * Time.deltaTime);
        if (transform.position.z < 0)
        {
            Destroy(gameObject);
        }
    }
}
