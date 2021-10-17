using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public enum Direction
{
	Left,
	Right,
	Front,
	Back
}

public class PieceController : MonoBehaviour
{
	[SerializeField] private ColorController colorData;
	[SerializeField] private CameraManager cameraManager;
	[SerializeField] private Transform reference;
	[SerializeField] private MeshRenderer referenceMesh;

	[SerializeField] private GameObject fallingPrefab;
	[SerializeField] private GameObject standPrefab;

	[SerializeField] private Transform last;

	[SerializeField] [Range(1, 5)] private float speed;
	[SerializeField] [Range(1, 2)] private float limit;

	private bool _isForward;
	private bool _isAxisX;

	private bool _isStop;

	private int _score;
	[SerializeField] private TextMeshProUGUI textScore;

	private void Start()
	{
		textScore.text = "";
	}

	private void UpdateText()
	{
		textScore.SetText(_score.ToString());
	}

	private void LateUpdate()
	{
		if (_isStop) return;

		var position = transform.position;
		var direction = _isForward ? 1 : -1;
		var move = speed * Time.deltaTime * direction;


		if (_isAxisX) position.x += move;
		else position.z += move;

		//Limit And Turn
		if (_isAxisX)
		{
			if (position.x < -limit || position.x > limit)
			{
				position.x = Mathf.Clamp(position.x, -limit, limit);
				_isForward = !_isForward;
			}
		}
		else
		{
			if (position.z < -limit || position.z > limit)
			{
				position.z = Mathf.Clamp(position.z, -limit, limit);
				_isForward = !_isForward;
			}
		}

		transform.position = position;
	}

	private void DivideObject(bool isAxisX, float value)
	{
		bool isFirstFalling = value > 0;

		var falling = Instantiate(fallingPrefab).transform;
		var stand = Instantiate(standPrefab).transform;

		//Size
		var fallingSize = reference.localScale;
		if (isAxisX) fallingSize.x = Math.Abs(value);
		else fallingSize.z = Math.Abs(value);
		falling.localScale = fallingSize;

		var standSize = reference.localScale;
		if (isAxisX) standSize.x = reference.localScale.x - Math.Abs(value);
		else standSize.z = reference.localScale.z - Math.Abs(value);
		stand.localScale = standSize;

		var minDirection = isAxisX ? Direction.Left : Direction.Back;
		var maxDirection = isAxisX ? Direction.Right : Direction.Front;

		//Position
		var fallingPosition = GetPositionEdge(referenceMesh, isFirstFalling ? minDirection : maxDirection);
		var fallingMultiply = (isFirstFalling ? 1 : -1);
		if (isAxisX) fallingPosition.x += (fallingSize.x / 2) * fallingMultiply;
		else fallingPosition.z += (fallingSize.z / 2) * fallingMultiply;
		falling.position = fallingPosition;

		var standPosition = GetPositionEdge(referenceMesh, !isFirstFalling ? minDirection : maxDirection);
		var standMultiply = (!isFirstFalling ? 1 : -1);
		if (isAxisX) standPosition.x += (standSize.x / 2) * standMultiply;
		else standPosition.z += (standSize.z / 2) * standMultiply;
		stand.position = standPosition;

		//Color
		var color =  colorData.GetColor(_score);
		stand.GetComponent<MeshRenderer>().material.color = color;
		falling.GetComponent<MeshRenderer>().material.color = color;
		referenceMesh.material.color = color;

		last = stand;
	}

	private Vector3 GetPositionEdge(MeshRenderer mesh, Direction direction)
	{
		var extents = mesh.bounds.extents;
		var position = mesh.transform.position;

		switch (direction)
		{
			case Direction.Left:
				position.x += -extents.x;
				break;
			case Direction.Right:
				position.x += extents.x;
				break;
			case Direction.Front:
				position.z += extents.z;
				break;
			case Direction.Back:
				position.z += -extents.z;
				break;
		}

		return position;
	}

	public void OnClick()
	{
		_isStop = true;

		var distance = last.position - transform.position;

		if (IsFail(distance))
		{
			Debug.Log("game over");
			return;
		}

		DivideObject(_isAxisX, _isAxisX ? distance.x : distance.z);

		//Reset
		_isAxisX = !_isAxisX;

		var newPosition = last.position;
		newPosition.y += transform.localScale.y;
		if (!_isAxisX) newPosition.z = limit;
		else newPosition.x = limit;
		transform.position = newPosition;

		transform.localScale = last.localScale;

		_isStop = false;

		_score++;
		UpdateText();

		cameraManager.Up();
	}

	private bool IsFail(Vector3 distance)
	{
		var origin = _isAxisX ? transform.localScale.x : transform.localScale.z;
		var current = _isAxisX ? Mathf.Abs(distance.x) : Mathf.Abs(distance.z);

		return current >= origin;
	}
}