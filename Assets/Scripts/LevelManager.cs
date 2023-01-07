using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public EnemySpawner spawner;
	public int currentLevel = 0;
	public TMPro.TextMeshProUGUI text;

	// Update is called once per frame
	void Update()
	{
		if (spawner.timeToSpawn < 0.75 && currentLevel < 3)
		{
			currentLevel = 3;
			StartCoroutine(ChangeLevelText());
		}
		else if (spawner.timeToSpawn < 5 && currentLevel < 2)
		{
			currentLevel = 2;
			StartCoroutine(ChangeLevelText());
		}
		else if (spawner.timeToSpawn < 9 && currentLevel < 1)
		{
			currentLevel = 1;
			StartCoroutine(ChangeLevelText());
		}
	}

	IEnumerator ChangeLevelText()
	{
		text.text = "level " + currentLevel + " reached!";
		text.gameObject.SetActive(true);
		yield return new WaitForSeconds(5);
		text.gameObject.SetActive(false);
	}
}
