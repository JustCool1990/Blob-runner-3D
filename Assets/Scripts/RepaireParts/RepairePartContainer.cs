using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairePartContainer : MonoBehaviour
{
    [SerializeField] private ColorAtribute _colorAtribute;

    private RepairePart[] _repaireParts;

    public ColorAtribute ColorAtribute => _colorAtribute;

    private void Start()
    {
        _repaireParts = GetComponentsInChildren<RepairePart>();

        SetRepairePartAtributes();
    }

    private void SetRepairePartAtributes()
    {
        foreach (var repairePart in _repaireParts)
        {
            repairePart.SetColorAtribute(this);
        }
    }
}

[System.Serializable]
public class ColorAtribute
{
    [SerializeField] private Material _material;
    [SerializeField] private Color _color;

    public Material Material => _material;
    public Color Color => _color;
}
