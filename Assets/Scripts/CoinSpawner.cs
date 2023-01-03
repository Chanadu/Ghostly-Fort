using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
	public Transform objectToSpawnParent;
	private float timeToSpawn;
	private float currentTimeToSpawn;
	public Transform player;
	// Start is called before the first frame update
	void Start()
	{
		timeToSpawn = Random.Range(2.0f, 5.0f);
		currentTimeToSpawn = timeToSpawn;
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
				Random.Range(3.0f, 7.0f);
				timeToSpawn -= Random.Range(0.1f, 0.4f);
			}
			currentTimeToSpawn = timeToSpawn;
		}
	}

	private void SpawnObject()
	{
		GameObject obj = CoinPooler.current.GetPooledObject();
		if (obj)
		{
			obj.SetActive(true);
			obj.transform.SetParent(objectToSpawnParent, true);
			float x = Random.Range(player.position.x - 5, player.position.x + 5);
			float y = Random.Range(player.position.y - 5, player.position.y + 5);
			obj.transform.SetPositionAndRotation(new Vector2(x, y), Quaternion.identity);
		}
	}
}
