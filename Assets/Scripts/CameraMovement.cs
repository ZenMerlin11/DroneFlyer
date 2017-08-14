using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public Transform target;	
	public Vector3 speed = new Vector3(10f, 10f, 5f);
	
	private Vector3 nextPosition;
	
	void Awake()
	{
		nextPosition = new Vector3
		(
			target.position.x,
			target.position.y,
			target.position.z
		);		
	}

	void LateUpdate()
	{
		if (target)
		{
			FollowPosition();
			LookAtPlayer();
		}
	}

	void FollowPosition()
	{
		nextPosition.x = Mathf.Lerp
		(
			transform.position.x,
			target.position.x,
			speed.x * Time.deltaTime
		);
		
		nextPosition.y = Mathf.Lerp
		(
			transform.position.y,
			target.position.y,
			speed.y * Time.deltaTime
		);
		
		nextPosition.z = Mathf.Lerp
		(
			transform.position.z,
			target.position.z,
			speed.z * Time.deltaTime
		);

		transform.position = nextPosition;
	}

	void LookAtPlayer()
	{
		transform.rotation = target.rotation;		
	}
}
