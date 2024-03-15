using System.Collections;
using UnityEngine;

public class MonsterEscape : MonoBehaviour
{
    public float startPosition;
    public float currentPosition;
    public float endPosition;
    Vector3 start;
    Vector3 end;
    public float distance;
    public float swims;
    private int strokes = 3;
    public float timeBtwnStrokes;
    public float strokeTime;
    public bool escaping;
    public bool isSwimming;

    void Start()
    {
        start.z = transform.position.z;
        end.z = endPosition;
        escape = controller.GetComponent<EscapeSpawner>();
        distance = (end.z - start.z) / swims;
        swims /= strokes;
    }
    void Update()
    {
        currentPosition = transform.position.z;

        if (escaping)
        {
            StartCoroutine(Swimming());
        }
        if (currentPosition > endPosition)
        {
            print("you lost");
            escape.escaped = true;
        }
    }
    IEnumerator Swimming()
    {
        for (int i = 0; i < strokes; i++)
        {
            currentPosition = transform.position.z;
            transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Lerp(currentPosition, distance, strokeTime));
            yield return new WaitForSeconds(timeBtwnStrokes);
        }

    }


















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

    private void Tart()
    {
        //enemy begins with minDistance
        currentDistance = minDistance;
        escape = controller.GetComponent<EscapeSpawner>();


        currentEscapeSpeed = beginEscapeSpeed;
    }

    void Pdate()
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
    }
}
