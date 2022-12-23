using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePooler : MonoBehaviour
{
	public static ProjectilePooler current;
	public GameObject pooledObject;
	public Transform pooledObjectHolder;
	public int pooledAmount;
	public bool willGrow;
	private List<GameObject> pooledObjects;

	public List<Sprite> projectileSprites;

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
				pooledObjects[i].GetComponent<SpriteRenderer>().sprite = projectileSprites[PlayerController.current.currentWeapon];
				pooledObjects[i].GetComponent<Projectile>().type = PlayerController.current.currentWeapon;
				return pooledObjects[i];
			}
		}

		if (willGrow)
		{
			GameObject obj = Instantiate(pooledObject);
			obj.transform.SetParent(pooledObjectHolder, true);
			obj.GetComponent<SpriteRenderer>().sprite = projectileSprites[PlayerController.current.currentWeapon];
			obj.GetComponent<Projectile>().type = PlayerController.current.currentWeapon;
			pooledObjects.Add(obj);
			return obj;
		}
		return null;
	}
}
