using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneHealth : MonoBehaviour
{
	public float maxCollisionAngle = 45.0f;
	public float maxCollisionForceMag = 45.0f;
	public GameObject explosion;
	public bool deadDrone = false;
	
	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			if (Vector3.Angle(Vector3.up, contact.normal) > maxCollisionAngle)
			{
				deadDrone = true;
			}
		}

		if (collision.relativeVelocity.magnitude > maxCollisionForceMag)
		{
			deadDrone = true;
		}

		if (deadDrone)
		{
			DestroyDrone();
		}
	}

	void DestroyDrone()
	{
		Instantiate(explosion, transform.position, transform.rotation);		
		Destroy(this.gameObject);
	}
}
