using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footblocks : MonoBehaviour
{
    [SerializeField] private ArrayLayout _arrayLayout;
    [SerializeField] private List<Footblock> _footblocks;

    private readonly int _rows = 5;
    private readonly int _collums = 3;

    private void Start()
    {
        int delta = 0;

        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _collums; j++)
            {
                if(_arrayLayout.Rows[i].Row[j] == true)
                    _footblocks[i + j + delta].gameObject.SetActive(true);
            }

            delta += _rows - _collums;
        }
    }
}
