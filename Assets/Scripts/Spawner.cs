using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject objectToSpawn;
	public Transform objectToSpawnParent;
	public float startingSpawnTime;
	public float timeToSpawn;
	private float currentTimeToSpawn;
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
			spawnObject();
			currentTimeToSpawn = timeToSpawn;
		}
	}

	private void spawnObject()
	{
		GameObject obj = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
		obj.transform.SetParent(objectToSpawnParent, true);
	}
}
