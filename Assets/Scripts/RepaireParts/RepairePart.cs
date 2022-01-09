using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class RepairePart : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    public ColorAtribute ColorAtribute { get; private set; }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void SetMaterial(Material material)
    {
        _meshRenderer.material = material;
    }

    public void SetColorAtribute(RepairePartContainer repairePartContainer)
    {
        ColorAtribute = repairePartContainer.ColorAtribute;

        SetMaterial(repairePartContainer.ColorAtribute.Material);
    }
}
