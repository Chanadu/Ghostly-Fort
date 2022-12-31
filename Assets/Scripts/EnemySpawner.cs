using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject objectToSpawn;
	public Transform objectToSpawnParent;
	public float startingSpawnTime;
	public float timeToSpawn;
	private float currentTimeToSpawn;
	public float speedUpTime = 0.2f;
	// Start is called before the first frame update
	void Start()
	{
		currentTimeToSpawn = startingSpawnTime;
	}

	// Update is called once per frame
	void Update()
	{
		UpdateTimer();
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
				timeToSpawn -= speedUpTime;
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
