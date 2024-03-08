using UnityEngine;

public class UpdateCollider : MonoBehaviour
{
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private MeshCollider meshCollider;

    void Start()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
    }

    void LateUpdate()
    {
        UpdateColliderMesh();
    }

    void UpdateColliderMesh()
    {
        if (skinnedMeshRenderer == null || meshCollider == null)
            return;

        Mesh skinnedMesh = new Mesh();
        skinnedMeshRenderer.BakeMesh(skinnedMesh);

        meshCollider.sharedMesh = null; //reset mesh
        meshCollider.sharedMesh = skinnedMesh;
    }
}
