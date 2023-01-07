using System.Collections;
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

	public Vector2 targetLocation;
	// Start is called before the first frame update
	void Start()
	{
		currentTimeToSpawn = startingSpawnTime;
		current = 0;
		speed = Random.Range(3.0f, 7.0f);
	}

	// Update is called once per frame
	void Update()
	{
		UpdateTimer();
	}

	private void FixedUpdate()
	{
		if (!(target[current].position.x == transform.position.x && (target[current].position.y == transform.position.y)))
		{
			transform.position = Vector2.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
			targetLocation = target[current].position;
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

			timeToSpawn -= Random.Range(0.2f, 0.5f);
			if (timeToSpawn > 0.25f)
			{
				timeToSpawn = 0.25f;
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
			obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, 0);
		}
	}
}
