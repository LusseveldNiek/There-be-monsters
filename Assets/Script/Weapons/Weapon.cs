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
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Monster")
        {
            monsterHit.NormalDamage(damage);
            HarpoonHit();
        }
        if (collision.transform.tag == "Crit")
        {
            monsterHit.CritHit(damage);
            HarpoonHit();
        }
        if (collision.transform.tag == "Water")
        {
            Destroy(gameObject);
        }
        if (collision.transform.tag == "Boat")
        {
            Destroy(gameObject);
        }
    }
    void HarpoonHit()
    {
        Destroy(transform.gameObject, destroyTime);
        RbHarpoen.constraints = RigidbodyConstraints.FreezeAll;
        Destroy(this);
    }
    public void SpawnHarpoon()
    {
        GameObject newHarpoon = Instantiate(harpoen, harpoenSpawnpiont.position, harpoenSpawnpiont.rotation, doos.transform);
        newHarpoon.name = gameObject.name;
    }
}
