using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island2 : MonoBehaviour
{
    public Transform bootR;
    public Transform bootL;
    public int curIndex;
    public float reachedTargetDistance;
    public float reachedTargetRotate;

    public Transform[] lands;
    public Transform[] lookAts;

    public Vector3 mapMovement;
    public bool turning;
    public float travelSpeed;
    public float travelTime;
    public float turnSpeed;
    public float turnTime;
    private float time;

    private void Start()
    {
        for (int i = 0; i < lookAts.Length - 1f; i++)
        {
            lookAts[i].LookAt(lands[i + 1]);
            //lookAts[i].rotation += Quaternion.i
        }
        time = Time.time;
    }

    void Update()
    {
        float dinstanceToTarget = Vector3.Distance(bootR.position, lands[curIndex].position);
        if (dinstanceToTarget < reachedTargetDistance)
        {
            // check of de index niet boven de lengte van de array uit komt.
            // do turn
            lands[curIndex].rotation = Quaternion.Slerp(lands[curIndex].rotation, lookAts[curIndex].rotation, turnSpeed);
            // if turn == ready : Signal time.
            //float rotationBetweenTargets = Quaternion.Angle(lands[curIndex].rotation, lookAts[curIndex].rotation);
            
        }
    }
}
