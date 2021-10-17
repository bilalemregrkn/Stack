using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	[SerializeField] private float time;
	[SerializeField] private AnimationCurve curve;
	[SerializeField] private float upValue;

	public void Up()
	{
		StopAllCoroutines();
		var target = transform.position;
		target.y += upValue;
		StartCoroutine(Move(transform, target, time, curve));
	}

	private IEnumerator Move(Transform current, Vector3 target, float time, AnimationCurve curve)
	{
		var passed = 0f;
		var init = current.position;
		while (passed < time)
		{
			passed += Time.deltaTime;
			var normalized = passed / time;
			normalized = curve.Evaluate(normalized);
			current.position = Vector3.Lerp(init, target, normalized);
			yield return null;
		}
	}
}