using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
	[SerializeField] private ColorData colorData;
	[SerializeField] private MeshRenderer referenceMesh;
	[SerializeField] private List<MeshRenderer> pivots;

	private List<Color> _listColor;

	private void Start()
	{
		_listColor = new List<Color>();

		var pool = new List<Color>(colorData.colors);
		var length = pool.Count;
		for (int i = 0; i < length; i++)
		{
			var index = Random.Range(0, pool.Count);
			var currentColor = pool[index];
			pool.RemoveAt(index);
			_listColor.Add(currentColor);
		}

		SetColor();
		referenceMesh.material.color = _listColor[0];
	}

	private void SetColor()
	{
		var baseColor = _listColor[Random.Range(1, _listColor.Count)];
		var target = _listColor[0];
		for (int i = 0; i < pivots.Count; i++)
		{
			var normalized = (float)(i + 1) / pivots.Count;
			pivots[i].material.color = Color.Lerp(target, baseColor, normalized);
		}
	}


	public Color GetColor(int score)
	{
		var index = score / colorData.scoreLimit;

		var baseColor = _listColor[index];
		var targetColor = _listColor[index + 1];

		var currentScore = score % colorData.scoreLimit;
		return Color.Lerp(baseColor, targetColor, (float)currentScore / colorData.scoreLimit);
	}
}