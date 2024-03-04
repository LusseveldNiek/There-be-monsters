using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] MonsterHealth monsterHit;
    public Transform harpoenSpawnpiont;
    public GameObject harpoen;
    public Rigidbody RbHarpoen;
    public GameObject doos;
    public int damage = 5;
    public int destroyTime = 10;


    private void Start()
    {
        monsterHit = FindObjectOfType<MonsterHealth>();
        //harpoenSpawnpiont = FindAnyObjectByType<>
        RbHarpoen.constraints = RigidbodyConstraints.None;
        RbHarpoen.useGravity = true;
        doos = GameObject.Find("SpawnHarpoen");
        transform.localScale = new Vector3(1, 1, 1);
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
        if (trigger.transform.tag == "Water")
        {
            SpawnHarpoon();
            Destroy(gameObject);
        }
        if (trigger.transform.tag == "Boat")
        {
            SpawnHarpoon();
            Destroy(gameObject);
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
        GameObject newHarpoon = Instantiate(harpoen, harpoenSpawnpiont.position, harpoenSpawnpiont.rotation, doos.transform);
        newHarpoon.name = gameObject.name;
        newHarpoon.transform.localScale = new Vector3(1, 1, 1);
    }
}
