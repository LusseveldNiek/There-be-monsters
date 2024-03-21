using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMaterials : MonoBehaviour
{
    public MonsterTestHP healthCode;
    private float monsterHP;
    private float minMonsterRedMaterial; //the number that decides when the red material will be activated

    public bool isHit;
    private float damageTime;

    public GameObject redMaterial;
    public GameObject whiteMaterial;

    private Coroutine whiteCoroutine;

    void Start()
    {
        monsterHP = healthCode.health;
        minMonsterRedMaterial = monsterHP / 4;
    }

    void Update()
    {
        if (isHit)
        {
            damageTime += Time.deltaTime;

            if (damageTime <= 0.5f)
            {

                if (whiteCoroutine == null)
                    whiteCoroutine = StartCoroutine(ToggleWhiteObject());
            }
            else
            {

                isHit = false;
                damageTime = 0;
                if (whiteCoroutine != null)
                {
                    StopCoroutine(whiteCoroutine);
                    whiteCoroutine = null;
                }
                whiteMaterial.SetActive(false);
                print("disabled");
            }
        }

        if (healthCode.health < minMonsterRedMaterial)
        {
            StartCoroutine(ToggleRedObject());
        }
    }

    private IEnumerator ToggleWhiteObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            whiteMaterial.SetActive(!whiteMaterial.activeSelf);
        }
    }

    private IEnumerator ToggleRedObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(.5f);
            redMaterial.SetActive(!redMaterial.activeSelf);
        }
    }
}
