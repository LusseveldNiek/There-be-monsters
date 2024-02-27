using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlokMove : MonoBehaviour
{
    public int speed;
    public Vector3 v3;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(v3 + -transform.forward * speed * Time.deltaTime);
    }
}
