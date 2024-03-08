using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Monster")
        {
            print("gothit");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            print("leftTrigger");
        }
    }
}
