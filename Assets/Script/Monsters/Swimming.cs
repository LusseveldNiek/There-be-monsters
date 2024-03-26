using System.Collections;
using System.Collections.Generic;
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
    private bool resetMovement;
    public float startTime;

    public float maxDistanceFromBoat;
    public EscapeSpawner escapeSpawner;

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

        if (escaping && !isSwimming && !hit && !resetMovement)
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
    }
    IEnumerator Swiming()
    {
        resetMovement = true;
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

        yield return new WaitForSeconds(0.5f);
        isSwimming = false;
        resetMovement = false;
        transform.position = endPos;
        Debug.Log("Stop swimming");
    }
}
