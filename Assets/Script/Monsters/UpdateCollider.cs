using UnityEngine;

public class UpdateCollider : MonoBehaviour
{
    private MeshCollider meshCollider;
    private SkinnedMeshRenderer skinnedMeshRenderer;

    void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    void Update()
    {
        // Update the mesh collider mesh with the current animated mesh
        meshCollider.sharedMesh = skinnedMeshRenderer.sharedMesh;
    }
}
