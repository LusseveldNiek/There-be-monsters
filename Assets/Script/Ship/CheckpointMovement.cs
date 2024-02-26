using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheckpointMovement : MonoBehaviour
{
    public Transform[] shipPositions;
    private int currentCheckpointIndex;
    public NavMeshAgent agent;

    void Update()
    {
        CheckpointSystem();
    }

    void CheckpointSystem()
    {
        Vector3 targetPosition = shipPositions[currentCheckpointIndex].position;
        agent.destination = targetPosition;

        //transform.LookAt(targetPosition);

        if (Vector3.Distance(transform.position, targetPosition) < 30)
        {
            currentCheckpointIndex = (currentCheckpointIndex + 1) % shipPositions.Length;
            print("newPosition");
        }
    }
}
