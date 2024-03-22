using UnityEngine;
using UnityEngine.UIElements;

public class Island : MonoBehaviour
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
    public void Update()
    {
        if (curIndex == lands.Length -1)
        {
            curIndex = 0;
        }
        //travelSpeed = travelSpeed * Time.deltaTime;

        float dinstanceToTarget = Vector3.Distance(bootR.position, lands[curIndex].position);
        if (dinstanceToTarget < reachedTargetDistance)
        {
            // check of de index niet boven de lengte van de array uit komt.
            // do turn
            lands[curIndex].rotation = Quaternion.Slerp(lands[curIndex].rotation, lookAts[curIndex].rotation, turnSpeed);
            // if turn == ready : Signal time.
            //float rotationBetweenTargets = Quaternion.Angle(lands[curIndex].rotation, lookAts[curIndex].rotation);
            //of
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
        if (turning)
        {
            // check of de index niet boven de lengte van de array uit komt.
            // do turn
            lands[curIndex].rotation = Quaternion.Slerp(lands[curIndex].rotation, lookAts[curIndex].rotation, turnSpeed);
            // if turn == ready : Signal time.
            Vector3 dirToLookAt = lookAts[curIndex].position - bootR.position;

            if (AreRotationsAligned(lands[curIndex], lookAts[curIndex], reachedTargetRotate)) 
            {
                print("rotatie gevonden");
            }

        }
        if (!turning)
        {
            //lands[curIndex].Translate(Vector3.left * travelSpeed * Time.deltaTime);
            lands[curIndex].position = Vector3.Lerp(lands[curIndex].position, bootR.position, travelSpeed);
        }
    }
    public void ResetRotation()
    {
        for (int i = 0; i < lookAts.Length; i++)
        {
            lookAts[i].LookAt(lands[i]);
            lands[i].rotation =  Quaternion.Euler(0, 0, 0);
        }
    }
    public bool AreRotationsAligned(Transform transform1, Transform transform2, float tolerancePercent)
    {
        // Calculate the difference in rotations
        Quaternion rotationDifference = Quaternion.Inverse(transform1.rotation) * transform2.rotation;

        // Calculate the angle difference in degrees
        float angleDifference = Quaternion.Angle(Quaternion.identity, rotationDifference);

        // Calculate the maximum allowed angle difference based on tolerance percent
        float maxAllowedDifference = 360f * tolerancePercent / 100f;

        // Check if the angle difference is within the tolerance
        return angleDifference <= maxAllowedDifference;
    }
}
