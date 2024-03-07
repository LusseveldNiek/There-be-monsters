using UnityEngine;

public class CheckpointMovement : MonoBehaviour
{
    public Transform[] shipPositions;
    private int currentCheckpointIndex;
    public Transform ship;
    public Transform shipRotation;
    public float speed;
    public Transform checkpointsManager;

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


        //reached checkpoint
        if (Vector3.Distance(ship.position, targetPosition) < 7)
        {
            print("working");

            //make terrain parent of previous checkpoint
            shipPositions[currentCheckpointIndex].parent = checkpointsManager.transform;
            //switch to next checkpoint
            currentCheckpointIndex = (currentCheckpointIndex + 1) % shipPositions.Length;
            //remove parent from next checkpoint
            shipPositions[currentCheckpointIndex].parent = null;
            //terrain will become child of checkpoint
            transform.parent = shipPositions[currentCheckpointIndex].transform;
            //rotate with checkpoint rotation
            shipPositions[currentCheckpointIndex].rotation = Quaternion.Euler(shipPositions[currentCheckpointIndex].rotation.x, shipPositions[currentCheckpointIndex].GetComponent<CheckpointRotation>().yRotation, shipPositions[currentCheckpointIndex].rotation.z);
            print("newPosition" + currentCheckpointIndex);

            //I NEED TO ROTATE THE TERRAIN BEFORE GOING TO NEXT CHECKPOINT!!!!
        }
    }
}
