using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : MonoBehaviour
{
	public static Disabler current;
	public EnemySpawner[] spawners;

	private void Start()
	{
		current = this;
	}
	private void OnEnable()
	{
		PlayerController.OnPlayerDeath += EndGame;
		Target.OnTargetDeath += EndGame;
	}

	private void OnDisable()
	{
		PlayerController.OnPlayerDeath -= EndGame;
		Target.OnTargetDeath -= EndGame;
	}

	public void DisableAll()
	{
		PlayerController.current.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		EnemyPooler.current.DisableEnemies();
		CoinSpawner.current.Disable();
		PlayerController.current.over = true;
		GameTimer.current.StopTime();

		foreach (EnemySpawner enemySpawner in spawners)
		{
			enemySpawner.Disable();
		}
	}

	public void EnableAll()
	{
		PlayerController.current.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		EnemyPooler.current.EnableEnemies();
		CoinSpawner.current.Enable();
		PlayerController.current.over = false;
		GameTimer.current.StartTime();

		foreach (EnemySpawner enemySpawner in spawners)
		{
			enemySpawner.Enable();
		}
	}

	public void EndGame()
	{
		DisableAll();
		SceneUiManager.current.EnableGameOverMenu();
	}
}
