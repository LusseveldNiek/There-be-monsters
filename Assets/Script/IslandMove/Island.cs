using UnityEngine;

public class Island : MonoBehaviour
{
    public Transform bootR;
    public Transform bootL;
    public int curIndex;
    public float reachedTargetDistance;

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
        for (int i = 0; i < lookAts.Length; i++)
        {
            lookAts[i].LookAt(lands[i]);
        }
        time = Time.time;
    }
    public void Update()
    {
        if (curIndex == lands.Length -1)
        {
            curIndex = 0;
        }
        //travelSpeed = travelSpeed * Time.deltaTime;
        turnSpeed = turnSpeed * Time.deltaTime;
        float dinstanceToTarget = Vector3.Distance(bootR.position, lands[curIndex].position);
        if (dinstanceToTarget < reachedTargetDistance)
        {
            // check of de index niet boven de lengte van de array uit komt.
            // do turn
            lands[curIndex].rotation = Quaternion.Slerp(lands[curIndex].rotation, lookAts[curIndex].rotation, travelSpeed);
            // if turn == ready : Signal time.
            bool rotationToTarget = Quaternion.ReferenceEquals(lands[curIndex].rotation, lookAts[curIndex].rotation);
            if (rotationToTarget)
            {
                if (curIndex == lands.Length - 1)
                {
                    curIndex = 0;
                    ResetRotation();
                }
                else
                {
                    // curIndex omhoog.
                    curIndex++;
                }
            }
        }
        if (!turning)
        {
            lands[curIndex].Translate(Vector3.left * travelSpeed * Time.deltaTime);
        }
        //lands[curIndex].position = Vector3.Lerp(lands[curIndex].position, bootR.position, travelSpeed);
    }
    public void ResetRotation()
    {
        for (int i = 0; i < lookAts.Length; i++)
        {
            lookAts[i].LookAt(lands[i]);
            lands[i].rotation =  Quaternion.Euler(0, 0, 0);
        }
    }
}
