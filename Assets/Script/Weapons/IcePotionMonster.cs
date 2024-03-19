using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Rendering;

public class IcePotionMonster : MonoBehaviour
{
    public bool frozen;
    private float freezeTime;
    public float freezeDuration;

    private float freezeValue;
    public float defrostSpeed;
    public Material freezeMaterial;
    void Update()
    {

        if (frozen)
        {
            freezeTime += Time.deltaTime;
            Debug.Log("aftellen");

            freezeMaterial.SetFloat("_Dissolve", freezeValue);
            if (freezeTime > freezeDuration)
            {
                freezeValue += defrostSpeed * Time.deltaTime;
                if(freezeValue > 1)
                {
                    freezeValue = 1;
                    freezeTime = 0;
                    frozen = false;
                    Debug.Log("unfreeze");
                }
            }
        }
    }
}
