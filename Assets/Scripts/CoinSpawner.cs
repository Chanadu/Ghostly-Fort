using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
	public static CoinSpawner current;
	public Transform objectToSpawnParent;
	private float timeToSpawn;
	private float currentTimeToSpawn;
	public Transform player;
	private bool disabled = false;
	// Start is called before the first frame update
	void Start()
	{
		current = this;
		timeToSpawn = Random.Range(4.5f, 7.0f);
		currentTimeToSpawn = timeToSpawn;
	}

	// Update is called once per frame
	void Update()
	{
		if (disabled)
		{
			return;
		}
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
				timeToSpawn = Random.Range(4.5f, 7.0f);
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

	public void Disable()
	{
		disabled = true;
	}

	public void Enable()
	{
		disabled = false;
	}
}
