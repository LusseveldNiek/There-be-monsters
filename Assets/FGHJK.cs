using UnityEngine;

public class RotationComparer : MonoBehaviour
{
    // Function to compare rotations of two transforms within a given percentage tolerance
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

    // Example usage
    void Start()
    {
        // Assuming you have two transforms called transform1 and transform2
        Transform transform1 = transform/* Get the first transform */;
        Transform transform2 = transform/* Get the second transform */;

        // Set the tolerance percentage
        float tolerancePercent = 10f; // You can change this value according to your requirements

        // Check if rotations are aligned within the given percentage tolerance

        if (AreRotationsAligned(transform1, transform2, tolerancePercent))
        {
            Debug.Log("Rotations are aligned within the given tolerance.");
        }
        else
        {
            Debug.Log("Rotations are not aligned within the given tolerance.");
        }
    }
}
