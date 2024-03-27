using System.Collections;
using UnityEngine;

public class Swimming : MonoBehaviour
{
    public Animator anim;
    public float startPosition;
    public float currentPosition;
    public float endPosition;
    Vector3 start;
    Vector3 current;
    Vector3 next;
    Vector3 end;
    public float distance; //distance needed
    public float timeBtwnStrokes; // time between strokes
    public bool escaping;
    public bool isSwimming;
    public bool hit;
    public float startTime;

    public float maxDistanceFromBoat;
    public EscapeSpawner escapeSpawner;
    public IcePotionMonster icePotionMonster;

    public bool isFrozen;
    public float slowDownSpeed;
    private float currentFreezePosition;
    void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        if(transform.localPosition.z > maxDistanceFromBoat)
        {
            escapeSpawner.escaped = true;
        }

        currentPosition = transform.localPosition.z;

        if (escaping && !isSwimming && !hit && !icePotionMonster.frozen)
        {
            StartCoroutine(Swiming());
            Debug.Log("esp");
            isSwimming = true;
        }
        if (currentPosition > endPosition)
        {
            print("you lost");
        }
        if (hit)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, startPosition);
            hit = false;
            escaping = false;
            StopAllCoroutines();
        }

        isFrozen = icePotionMonster.frozen;
        if(isFrozen && currentPosition > startPosition)
        {
            print("slowing down");
            currentFreezePosition = transform.localPosition.z - (slowDownSpeed * Time.deltaTime);
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, currentFreezePosition);
        }

        else
        {
            currentFreezePosition = 0;
        }
    }
    IEnumerator Swiming()
    {
        float elapsedTime = 0f;
        Vector3 startPos = transform.position;
        Vector3 endPos = transform.position - transform.forward * distance;

        while (elapsedTime < timeBtwnStrokes)
        {
            //yield return new WaitForSeconds(0.5f);
            transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / timeBtwnStrokes);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);
        isSwimming = false;
        transform.position = endPos;
        Debug.Log("Stop swimming");
    }
}
