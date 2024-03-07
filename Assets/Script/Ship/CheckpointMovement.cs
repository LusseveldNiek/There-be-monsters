using UnityEngine;

public class CheckpointMovement : MonoBehaviour
{
    public Transform[] shipPositions;
    public Transform[] originalShipPositions;
    private int currentCheckpointIndex;
    private int rotateCheckpoint;
    public Transform ship;
    public Transform shipRotation;
    public float speed;
    public Transform checkpointsManager;
    public float rotationSpeed;
    public bool isRotating;
    private Quaternion targetRotation;

    void Update()
    {
        CheckpointSystem();
    }

    void CheckpointSystem()
    {
        Vector3 targetPosition = shipPositions[currentCheckpointIndex].position;

        //calculate direction vector from boat to checkpoint
        Vector3 direction = (ship.position - targetPosition).normalized;

        //move the checkpoint in a direction towards the boat
        Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;
        transform.position = newPosition;

        shipRotation.LookAt(targetPosition);


        // reached checkpoint
        if (Vector3.Distance(ship.position, targetPosition) < 7)
        {
            print("working");
            shipPositions[currentCheckpointIndex].parent = null;
            // terrain will become child of checkpoint
            transform.parent = shipPositions[currentCheckpointIndex].transform;

            // Get the target rotation from the checkpoint
            targetRotation = Quaternion.Euler(shipPositions[currentCheckpointIndex].rotation.x, shipPositions[currentCheckpointIndex].GetComponent<CheckpointRotation>().yRotation, shipPositions[currentCheckpointIndex].rotation.z);

            rotateCheckpoint = currentCheckpointIndex;
            isRotating = true;

            // switch to next checkpoint
            currentCheckpointIndex = (currentCheckpointIndex + 1) % shipPositions.Length;

            print("newPosition" + currentCheckpointIndex);

            if(currentCheckpointIndex == 16)
            {
                for (int i = 0; i < originalShipPositions.Length; i++)
                {
                    shipPositions[i].position = originalShipPositions[i].position;
                }
            }
        }

        if(isRotating)
        {
            //smoothly rotate towards the target rotation
            shipPositions[rotateCheckpoint].rotation = Quaternion.RotateTowards(shipPositions[rotateCheckpoint].rotation, targetRotation, rotationSpeed * Time.deltaTime);

            //check if the difference between current rotation and target rotation is very small
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                isRotating = false; //turn off rotation
                transform.parent = null;
                shipPositions[rotateCheckpoint].parent = checkpointsManager;
            }
        }
    }
}
