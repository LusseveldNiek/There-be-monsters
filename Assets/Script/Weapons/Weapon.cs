using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] MonsterTestHP monsterHit;
    public Transform harpoenSpawnpiont;
    public GameObject harpoen;
    public Rigidbody RbHarpoen;
    public GameObject doos;
    public int damage = 5;
    public int destroyTime = 10;
    public GameObject soundGameObject;


    private void Start()
    {
        monsterHit = FindObjectOfType<MonsterTestHP>();
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
            transform.parent = collision.gameObject.transform;

            GameObject soundPrefab = Instantiate(soundGameObject, transform.position, Quaternion.identity);
        }
        if (collision.transform.tag == "Crit")
        {
            monsterHit.CritHit(damage);
            HarpoonHit();
            transform.parent = collision.gameObject.transform;
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
