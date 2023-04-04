using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public float timeToDisable;
	private float currentTime;

	private void OnEnable()
	{
		currentTime = timeToDisable;
	}

	private void Update()
	{
		if (gameObject.activeInHierarchy)
		{
			currentTime -= Time.deltaTime;
		}
		if (currentTime <= 0)
		{
			Disable();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Score.current.IncreaseScore(100);
			Disable();
		}
	}

	public void Disable()
	{
		gameObject.SetActive(false);
	}

	private void OnDisable()
	{
		Disable();
	}
}
