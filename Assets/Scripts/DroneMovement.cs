using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public Boundary
	(
		float xMin, float xMax, float yMin, float yMax, float zMin, float zMax
	)
	{
		this.xMin = xMin;
		this.xMax = xMax;
		this.yMin = yMin;
		this.yMax = yMax;
		this.zMin = zMin;
		this.zMax = zMax;
	}
	public float xMin, xMax, yMin, yMax, zMin, zMax;
}

public class DroneMovement : MonoBehaviour
{
	public Transform mesh;
	public float ySpeed = 60.0f;
	public float zSpeed = 200.0f;
	public float xSpeed = 200.0f;
	public float yawSpeed = 1.5f;
	public Boundary boundary = new Boundary
	(
		-250.0f, 240.0f, 0.0f, 70.0f, -250.0f, 230.0f
	);
		

	private Rigidbody rb;
	private float yDirForce = 0.0f;
	private float zDirForce = 0.0f;
	private float xDirForce = 0.0f;
	private float yawTorque = 0.0f;
	private float pitch = 0.0f;
	private float maxPitch = 25.0f;
	private float roll = 0.0f;
	private float maxRoll = 25.0f;
	private float deadZoneRange = 2.0f;
	private AudioSource engineSound;
	private float lowEnginePitch = 0.6f;
	private float highEnginePitch = 2.0f;
	private float enginePitchRange;
	

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		engineSound = GetComponent<AudioSource>();
		enginePitchRange = highEnginePitch - lowEnginePitch;
	}
	
	void FixedUpdate()
	{
		// Handle inputs and update speed of engine sound
		ProcessInput();
		ProcessEngineSound();
		
		// Update velocity, torque, pitch, and roll
		rb.AddRelativeForce(new Vector3(xDirForce, yDirForce, zDirForce));
		rb.AddTorque(0.0f, yawTorque, 0.0f);
		mesh.eulerAngles = new Vector3
		(
			pitch,
			this.transform.eulerAngles.y,
			roll
		);
		
		// Clamp drone position to level boundaries
		rb.position = new Vector3
		(
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax + 10.0f),
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);
	}

	void ProcessInput()
	{
		ProcessCollective();
		ProcessCollective();
		ProcessYaw();
		ProcessZMovement();
		ProcessXMovement();
	}

	void ProcessCollective()
	{
		float stickInput = -Input.GetAxis("LS-Vertical") * ySpeed;
		yDirForce = ClampForce
		(
			stickInput,
			transform.position.y,
			boundary.yMin,
			boundary.yMax
		);
	}

	void ProcessYaw()
	{
		yawTorque = Input.GetAxis("LS-Horizontal") * yawSpeed;
	}

	void ProcessZMovement()
	{
		float stickInput = Input.GetAxis("RS-Vertical");
		zDirForce = -stickInput * zSpeed;
		pitch = -stickInput * maxPitch;
	}

	void ProcessXMovement()
	{
		float stickInput = Input.GetAxis("RS-Horizontal");
		xDirForce = stickInput * xSpeed;
		roll = -stickInput * maxRoll;
	}

	float ClampForce(float force, float pos, float minPos, float maxPos)
	{
		if (pos < (minPos) && force < 0)
		{
			return 0.0f;
		}
		else if (pos > (maxPos - deadZoneRange) && force > 0)
		{
			return 0.0f;
		}
		else
		{
			return force;
		}		
	}

	void ProcessEngineSound()
	{
		float speed = rb.velocity.magnitude / 100;
		engineSound.pitch = lowEnginePitch + (speed * enginePitchRange);
	}
}