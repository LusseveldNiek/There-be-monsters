using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] MonsterHealth monsterHit;
    public Transform harpoenSpawnpiont;
    public GameObject harpoen;
    Rigidbody RbHarpoen;
    public float damage = 5;
    public int destroyTime;


    private void Start()
    {
        monsterHit = FindObjectOfType<MonsterHealth>();
        RbHarpoen = GetComponentInParent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.transform.tag == "Monster")
        {
            SpawnHarpoon();
            monsterHit.NormalDamage(damage);
            HarpoonHit();
        }
        if (trigger.transform.tag == "Crit")
        {
            SpawnHarpoon();
            monsterHit.CritHit(damage);
            HarpoonHit();
        }
    }
    void HarpoonHit()
    {
        Destroy(transform.gameObject, destroyTime);
        RbHarpoen.constraints = RigidbodyConstraints.FreezeAll;
        Destroy(this);
    }
    void SpawnHarpoon()
    {
        GameObject newHarpoon = Instantiate(harpoen, harpoenSpawnpiont.position, Quaternion.identity);
    }
}
