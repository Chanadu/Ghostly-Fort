﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject objectToSpawn;
	public Transform objectToSpawnParent;
	public float startingSpawnTime;
	public Transform[] target;
	private float speed;
	public int current;
	public float timeToSpawn;
	private float currentTimeToSpawn;
	// Start is called before the first frame update
	void Start()
	{
		timeToSpawn = Random.Range(4.0f, 7.0f);
		currentTimeToSpawn = timeToSpawn;
		current = 0;
		speed = Random.Range(2, 7);
	}

	// Update is called once per frame
	void Update()
	{
		UpdateTimer();
	}

	private void FixedUpdate()
	{
		if (!target[current].position.Equals(transform.position))
		{
			transform.position = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
		}
		else
		{
			current++;
			if (current == target.Length)
			{
				current = 0;
			}
		}

	}

	private void UpdateTimer()
	{
		if (currentTimeToSpawn > 0)
		{
			currentTimeToSpawn -= Time.deltaTime;
		}
		else
		{
			SpawnObject();

			if (timeToSpawn > 2)
			{
				Random.Range(3.0f, 7.0f);
				timeToSpawn -= Random.Range(0.01f, 0.3f);
			}
			currentTimeToSpawn = timeToSpawn;
		}
	}

	private void SpawnObject()
	{
		GameObject obj = EnemyPooler.current.GetPooledObject();
		if (obj)
		{
			obj.SetActive(true);
			obj.transform.SetParent(objectToSpawnParent, true);
			obj.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
		}
	}
}
