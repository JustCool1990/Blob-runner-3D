using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairePart : MonoBehaviour
{
    [SerializeField] private int _repairCount;

    public int RepairCount => _repairCount;
}
