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

        // Calculate direction vector from boat to checkpoint
        Vector3 direction = (ship.position - targetPosition).normalized;

        // Move the checkpoint in a direction towards the boat
        Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;
        transform.position = newPosition;

        shipRotation.LookAt(targetPosition);



        if (Vector3.Distance(ship.position, targetPosition) < 7)
        {
            print("working");
            shipPositions[currentCheckpointIndex].parent = checkpointsManager.transform;
            currentCheckpointIndex = (currentCheckpointIndex + 1) % shipPositions.Length;
            shipPositions[currentCheckpointIndex].parent = null;
            transform.parent = shipPositions[currentCheckpointIndex].transform;
            shipPositions[currentCheckpointIndex].rotation = Quaternion.Euler(shipPositions[currentCheckpointIndex].rotation.x, shipPositions[currentCheckpointIndex].GetComponent<CheckpointRotation>().yRotation, shipPositions[currentCheckpointIndex].rotation.z);
            print("newPosition" + currentCheckpointIndex);
        }
    }
}
