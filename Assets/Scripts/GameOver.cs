using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public DroneHealth droneHealth;
	public float restartDelay = 5.0f;

	private Animator GameOverScreen;
	private float restartTimer = 0.0f;

	void Awake()
	{
		GameOverScreen = GetComponent<Animator>();
	}

	void Update()
	{
		if (droneHealth.deadDrone)
		{
			GameOverScreen.SetTrigger("GameOver");
			restartTimer += Time.deltaTime;

			if (restartTimer > restartDelay)
			{
				// Restart level 0
				SceneManager.LoadScene(0);
			}
		}
	}
}
