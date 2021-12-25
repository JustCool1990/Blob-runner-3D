using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BodyPart : MonoBehaviour
{
    [SerializeField] private BodyPart[] _relatedBodyParts;
    [SerializeField] private BodyPartName _bodyPartName;

    private bool _hasBroken = false;

    public BodyPartName BodyPartName => _bodyPartName;
    public bool HasBroken => _hasBroken;
    public event UnityAction<BodyPartName> Broken;
    public event UnityAction Repaired;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Obstacle obstacle))
        {
            if(_relatedBodyParts.Length > 1)
            {
                foreach (var bodyPart in _relatedBodyParts)
                {
                    if (bodyPart.HasBroken == true) 
                        continue;

                    bodyPart.UpdateBrokenStatus(true);
                    bodyPart.SeparatePiece();
                }
            }
            else
            {
                UpdateBrokenStatus(true);
                SeparatePiece();
            }
        }
    }

    public void UpdateBrokenStatus(bool status = false)
    {
        _hasBroken = status;
    }

    public void SeparatePiece()
    {
        Broken?.Invoke(_bodyPartName);
        gameObject.SetActive(false);
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
