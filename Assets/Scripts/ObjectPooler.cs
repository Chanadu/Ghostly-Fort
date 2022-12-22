﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
	public static ObjectPooler current;
	public GameObject pooledObject;
	public Transform pooledObjectHolder;
	public int pooledAmount;
	public bool willGrow;

	private List<GameObject> pooledObjects;

	// Start is called before the first frame update
	void Start()
	{
		current = this;
		pooledObjects = new List<GameObject>();
		for (int i = 0; i < pooledAmount; i++)
		{
			GameObject obj = Instantiate(pooledObject);
			obj.SetActive(false);
			obj.transform.SetParent(pooledObjectHolder, true);
			pooledObjects.Add(obj);
		}
	}

	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++)
		{
			if (!pooledObjects[i].activeInHierarchy)
			{
				return pooledObjects[i];
			}
		}

		if (willGrow)
		{
			GameObject obj = Instantiate(pooledObject);
			obj.transform.SetParent(pooledObjectHolder, true);
			pooledObjects.Add(obj);
			return obj;
		}
		return null;
	}
}
