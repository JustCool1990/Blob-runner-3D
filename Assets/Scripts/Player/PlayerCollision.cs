using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    public event UnityAction<int> RepairePartPicked;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out RepairePart repairePart))
        {
            RepairePartPicked?.Invoke(repairePart.RepairCount);
            repairePart.gameObject.SetActive(false);
        }
    }
}
