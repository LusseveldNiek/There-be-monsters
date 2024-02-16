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

    private void Start()
    {
        monsterHit = FindObjectOfType<MonsterHealth>();
        RbHarpoen = GetComponentInParent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Monster")
        {
            GameObject newHarpoon = Instantiate(harpoen, harpoenSpawnpiont.position, Quaternion.identity);
            RbHarpoen.constraints = RigidbodyConstraints.FreezeAll;
            monsterHit.NormalDamage(damage);
        }
    }
}
