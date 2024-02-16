using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            print("hit player");
        }
    }
}
