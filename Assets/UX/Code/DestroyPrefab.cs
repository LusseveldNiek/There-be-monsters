using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{
    
    void Update()
    {
        Destroy(gameObject, 2);
    }
}
