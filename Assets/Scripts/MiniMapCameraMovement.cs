using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCameraMovement : MonoBehaviour
{
	public Transform playerDrone;
	private float cameraHeight = 85.0f;

	void LateUpdate()
	{
		if (playerDrone)
		{
			transform.position = (new Vector3
			(
				playerDrone.position.x,
				cameraHeight,
				playerDrone.position.z)
			);
		}
	}
}
