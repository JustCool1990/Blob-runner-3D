using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RaymarcherPackage;

[RequireComponent(typeof(RM_Object))]
public class BodyPart : MonoBehaviour
{
    [SerializeField] private BodyPart[] _relatedBodyParts;
    [SerializeField] private BodyPartName _bodyPartName;

    private RM_Object _rm_Object;
    private bool _hasBroken = false;
    private Transform _parent;

    public BodyPartName BodyPartName => _bodyPartName;
    public bool HasBroken => _hasBroken;
    public event UnityAction<BodyPartName> Brokened;
    public event UnityAction<BodyPartName> Repaired;

    private void Awake()
    {
        _parent = transform.parent;
        _rm_Object = GetComponent<RM_Object>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Obstacle obstacle))
        {
            if(_relatedBodyParts.Length > 1)
            {
                foreach (var bodyPart in _relatedBodyParts)
                {
                    if (bodyPart.HasBroken == false)
                    {
                        DesableBrokenPart(bodyPart, obstacle);
                    }
                }
            }
            else
            {
                if (_hasBroken == false)
                {
                    DesableBrokenPart(this, obstacle);
                }
            }
        }
    }

    private void DesableBrokenPart(BodyPart bodyPart, Obstacle obstacle)
    {
        bodyPart.UpdateBrokenStatus(true);
        bodyPart.SeparatePiece(obstacle);
    }

    private void UpdateBrokenStatus(bool status = false)
    {
        _hasBroken = status;
    }

    private void SeparatePiece(Obstacle obstacle)
    {
        Brokened?.Invoke(_bodyPartName);
        transform.SetParent(obstacle.transform);
        transform.localScale = Vector3.one;
    }

    private void ResetTransform()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }

    public void RepairePiece(Color color)
    {
        UpdateBrokenStatus(false);
        transform.SetParent(_parent);
        ResetTransform();
        _rm_Object.rmColor = color;

        Repaired?.Invoke(_bodyPartName);
    }
}

public enum BodyPartName
{
    Head,
    Belly,
    UpperLeftHandPart,
    LowerLeftHandPart,
    UpperRightHandPart,
    LowerRightHandPart,
    UpperLeftLegPart,
    LowerLeftLegPart,
    UpperRightLegPart,
    LowerRightLegPart,
}
