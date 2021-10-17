using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create ColorData", fileName = "ColorData", order = 0)]
public class ColorData : ScriptableObject
{
	public List<Color> colors;
	public int scoreLimit;
}