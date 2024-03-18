using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePotionMonster : MonoBehaviour
{
    public bool frozen;
    private float freezeTime;
    public float freezeDuration;

    private float freezeValue;
    public float defrostSpeed;
    void Update()
    {
        GetComponent<SkinnedMeshRenderer>().materials[0].SetFloat("Dissolve", freezeValue);
        GetComponent<SkinnedMeshRenderer>().materials[1].SetFloat("Dissolve", freezeValue);


        if (frozen)
        {
            freezeTime += Time.deltaTime;
            Debug.Log("aftellen");
            if (freezeTime > freezeDuration)
            {
                GetComponent<SkinnedMeshRenderer>().materials[0].SetFloat("Dissolve", freezeValue);
                freezeValue += defrostSpeed * Time.deltaTime;
                if(freezeValue > 1)
                {
                    freezeValue = 0;
                    freezeTime = 0;
                    frozen = false;
                    Debug.Log("unfreeze");
                }
            }
        }
    }
}
