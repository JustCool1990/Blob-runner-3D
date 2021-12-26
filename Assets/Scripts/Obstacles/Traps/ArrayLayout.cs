using UnityEngine;
using System.Collections;

[System.Serializable]
public class ArrayLayout
{
	[System.Serializable]
	public struct RowData
	{
		public bool[] Row;
	}

	public RowData[] Rows = new RowData[12];
}
