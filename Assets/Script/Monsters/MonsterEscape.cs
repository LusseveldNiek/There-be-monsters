using UnityEngine;

public class MonsterEscape : MonoBehaviour
{
    //added speed per frame
    public float escapeSpeed;
    public bool isEscaping;

    //distance atm
    private float currentDistance;

    //distance until escape
    public float maxDistance;

    //minimum distance
    public float minDistance;

    //gameover canvas
    public EscapeSpawner escape;
    public GameObject controller;

    //animatie stop
    public AnimatieHit animatieHit;

    //freeze
    public IcePotionMonster icePotionMonster;
    public float freezeSpeed;

    private void Start()
    {
        //enemy begins with minDistance
        currentDistance = minDistance;
        escape = controller.GetComponent<EscapeSpawner>();
    }

    void Update()
    {
        //set distance
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, currentDistance);

        if(currentDistance < maxDistance)
        {
            if(isEscaping)
            {
                print("works");

                //add escape speed
                currentDistance += escapeSpeed * Time.deltaTime;
            }
        }

        if(icePotionMonster.frozen)
        {
            isEscaping = false;

            if(currentDistance > minDistance)
            {
                currentDistance -= freezeSpeed * Time.deltaTime;
            }
        }


        //escape
        if(currentDistance > maxDistance)
        {
            print("you lost");
            escape.escaped = true;
        }
    }
}
