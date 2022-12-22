using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBar : MonoBehaviour
{
	public GameObject heartPrefab;
	private PlayerController player;
	private List<Heart> hearts = new List<Heart>();

	private void Update()
	{
		DrawHearts();
	}
	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		if (!player)
		{
			Debug.Log("NO player");
		}
	}

	public void ClearHearts()
	{
		foreach (Transform t in transform)
		{
			Destroy(t.gameObject);
		}
		hearts = new List<Heart>();
	}

	public void CreateEmptyHeart()
	{

		GameObject newHeart = Instantiate(heartPrefab);
		newHeart.transform.SetParent(transform);

		Heart heartComponent = newHeart.GetComponent<Heart>();
		heartComponent.SetHeartImage(HeartStatus.Empty);
		hearts.Add(heartComponent);
	}

	public void DrawHearts()
	{
		float maxHealthRemainder = player.maxHealth % 2;
		int heartsToMake = (int)((player.maxHealth / 2) + maxHealthRemainder);

		for (int i = 0; i < heartsToMake; i++)
		{
			CreateEmptyHeart();
		}

		for (int i = 0; i < hearts.Count; i++)
		{
			int heartStatusRemainder = (int)Mathf.Clamp(player.health - (i * 2), 0, 2);
			hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
		}
	}
}
