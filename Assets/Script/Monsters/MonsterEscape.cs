using UnityEngine;

public class MonsterEscape : MonoBehaviour
{
    //added speed per frame
    public float currentEscapeSpeed;
    public float beginEscapeSpeed;
    public float escapeSpeedRemoval;
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

    [Header("Freezing")]
    public float freezeTime;
    private float freezeCounter;

    public float freezeSpeed;

    public bool isFrozen;
    public Material normalMaterial;

    private void Start()
    {
        //enemy begins with minDistance
        currentDistance = minDistance;
        escape = controller.GetComponent<EscapeSpawner>();


        currentEscapeSpeed = beginEscapeSpeed;
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
                currentDistance += currentEscapeSpeed;

                currentEscapeSpeed -= escapeSpeedRemoval;

                //done with movement
                if(currentEscapeSpeed <= 0)
                {
                    currentEscapeSpeed = beginEscapeSpeed;
                    isEscaping = false;
                    print("doneEscaping");
                }
            }
        }


        //escape
        if(currentDistance > maxDistance)
        {
            print("you lost");
            escape.escaped = true;
        }

        if(isFrozen)
        {
            freezeCounter += Time.deltaTime;
            if(currentDistance > minDistance)
            {
                currentDistance -= freezeSpeed * Time.deltaTime;
            }

            if(freezeCounter > freezeTime)
            {
                GetComponent<MeshRenderer>().material = normalMaterial;
                freezeCounter = 0;
                isFrozen = false;
            }
        }
    }
}
