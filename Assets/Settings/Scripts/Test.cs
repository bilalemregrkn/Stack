using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
	// [SerializeField] private Transform pivot;
	// [SerializeField] private Transform reference;
	//
	// [SerializeField] private Transform falling;
	// [SerializeField] private Transform stand;
	//
	//
	// [SerializeField] private float TEST_VALUE;
	// [SerializeField] private bool TEST_IS_FRONT;
	//
	// [ContextMenu("Test")]
	// private void TEST()
	// {
	// 	Create(TEST_IS_FRONT, TEST_VALUE);
	// }
	//
	// private void Create(bool isHorizontal, float distance)
	// {
	// 	var isFallingFront = distance > 0;
	//
	// 	var fallingSize = reference.localScale;
	// 	if (isHorizontal) fallingSize.x = Mathf.Abs(distance);
	// 	else fallingSize.z = Mathf.Abs(distance);
	// 	falling.localScale = fallingSize;
	//
	// 	var standSize = reference.localScale;
	// 	if (isHorizontal) standSize.x = reference.localScale.x - Mathf.Abs(distance);
	// 	else standSize.z = reference.localScale.z - Mathf.Abs(distance);
	// 	stand.localScale = standSize;
	//
	// 	var right = GetPositionEdge(reference.GetComponent<MeshRenderer>(), Direction.Right);
	// 	var left = GetPositionEdge(reference.GetComponent<MeshRenderer>(), Direction.Left);
	// 	var up = GetPositionEdge(reference.GetComponent<MeshRenderer>(), Direction.Up);
	// 	var down = GetPositionEdge(reference.GetComponent<MeshRenderer>(), Direction.Down);
	//
	// 	var front = isHorizontal ? right : up;
	// 	var back = isHorizontal ? left : down;
	//
	// 	var fallingPosition = isFallingFront ? front : back;
	// 	if (isHorizontal) fallingPosition.x += (fallingSize.x / 2) * (isFallingFront ? -1 : 1);
	// 	else fallingPosition.z += (fallingSize.z / 2) * (isFallingFront ? -1 : 1);
	//
	// 	falling.position = fallingPosition;
	//
	// 	var standPosition = !isFallingFront ? front : back;
	// 	if (isHorizontal) standPosition.x += (standSize.x / 2) * (!isFallingFront ? -1 : 1);
	// 	else standPosition.z += (standSize.z / 2) * (!isFallingFront ? -1 : 1);
	// 	stand.position = standPosition;
	// }
	//
	// private void Create(float distance)
	// {
	// 	var isFallingFront = distance > 0;
	//
	// 	var fallingSize = reference.localScale;
	// 	fallingSize.x = Mathf.Abs(distance);
	// 	falling.localScale = fallingSize;
	//
	// 	var standSize = reference.localScale;
	// 	standSize.x = reference.localScale.x - Mathf.Abs(distance);
	// 	stand.localScale = standSize;
	//
	// 	var right = GetPositionEdge(reference.GetComponent<MeshRenderer>(), Direction.Right);
	// 	var left = GetPositionEdge(reference.GetComponent<MeshRenderer>(), Direction.Left);
	//
	// 	var fallingPosition = isFallingFront ? right : left;
	// 	fallingPosition.x += (fallingSize.x / 2) * (isFallingFront ? -1 : 1);
	// 	falling.position = fallingPosition;
	//
	// 	var standPosition = !isFallingFront ? right : left;
	// 	standPosition.x += (standSize.x / 2) * (!isFallingFront ? -1 : 1);
	// 	stand.position = standPosition;
	// }
	//
	// private Vector3 GetPositionEdge(MeshRenderer meshRenderer, Direction direction)
	// {
	// 	var extents = meshRenderer.bounds.extents;
	// 	var position = meshRenderer.transform.position;
	//
	// 	switch (direction)
	// 	{
	// 		case Direction.Up:
	// 			position.z += extents.z;
	// 			break;
	// 		case Direction.Left:
	// 			position.x += -extents.x;
	// 			break;
	// 		case Direction.Right:
	// 			position.x += extents.x;
	// 			break;
	// 		case Direction.Down:
	// 			position.z += -extents.z;
	// 			break;
	// 	}
	//
	// 	return position;
	// }
	//
	// enum Direction
	// {
	// 	Up,
	// 	Left,
	// 	Right,
	// 	Down
	// }
}