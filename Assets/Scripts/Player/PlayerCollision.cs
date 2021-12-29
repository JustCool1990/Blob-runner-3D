using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    public event UnityAction<Color> RepairePartPicked;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out RepairePart repairePart))
        {
            RepairePartPicked?.Invoke(repairePart.ColorAtribute.Color);
            repairePart.gameObject.SetActive(false);
        }
    }
}
