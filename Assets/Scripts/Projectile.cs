using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public Rigidbody2D rb;
	public float timeToDisable;
	private float currentTime;
	public int type;
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
		switch (other.gameObject.tag)
		{
			case "Wall":
				Disable();
				break;
			case "Enemy":
				if (other.gameObject.GetComponent<Enemy>().enemyType == type)
				{
					Enemy enemy = other.gameObject.GetComponent<Enemy>();
					enemy.TakeDamage(1);
					Disable();
				}
				break;
		}
	}

	public void Disable()
	{
		gameObject.SetActive(false);
		currentTime = 0;
	}

	private void OnDisable()
	{
		Disable();
	}
}
