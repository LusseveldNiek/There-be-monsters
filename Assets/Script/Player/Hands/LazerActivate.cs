using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerActivate : MonoBehaviour
{
    public GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        hand.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit)) 
        {
            if(hit.transform.tag == "UI")
            {
                hand.SetActive(true);
            }
        }
        else
        {
            hand.SetActive(false);
        }
    }
}
