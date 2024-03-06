using UnityEngine;

public class CheckpointMovement : MonoBehaviour
{
    public Transform[] shipPositions;
    private int currentCheckpointIndex;
    public Transform ship;
    public Transform shipRotation;
    public float speed;

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

        transform.rotation = Quaternion.Euler(transform.rotation.x, shipRotation.rotation.y, transform.rotation.z);

        if (Vector3.Distance(ship.position, targetPosition) < 30)
        {
            currentCheckpointIndex = (currentCheckpointIndex + 1) % shipPositions.Length;
            print("newPosition" + currentCheckpointIndex);
        }
    }
}
