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
    public float distance;
    public float swims;
    private int strokes = 3;
    public float timeBtwnStrokes;
    public float strokeTime;
    public float speed;
    public bool escaping;
    public bool isSwimming;
    public bool hit;
    public float startTime;

    void Start()
    {
        anim = GetComponent<Animator>();
        startTime = Time.time;
        start.z = transform.localPosition.z;
        end.z = endPosition;
        distance = (end.z - start.z) / swims;
        swims /= strokes;
    }
    void Update()
    {
        currentPosition = transform.localPosition.z;

        if (escaping && !isSwimming && !hit)
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
        for (int i = 0; i < strokes; i++)
        {
            for (int j = 0; j < strokes; j++)
            {
                float fracComplete = (Time.time - startTime) / strokeTime;
                currentPosition += distance / strokes;
                current = transform.localPosition;
                next = current;
                next.z += distance / swims;
                //transform.localPosition = Vector3.Slerp(current, next, fracComplete);
                transform.localPosition = next;
                Debug.Log("moving");
            }
            yield return new WaitForSeconds(timeBtwnStrokes);
            Debug.Log("int");
        }
        isSwimming = false;
        Debug.Log("stop swimming");
    }
}
