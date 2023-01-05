using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUiManager : MonoBehaviour
{
	public GameObject gameOverMenu;

	private void OnEnable()
	{
		PlayerController.OnPlayerDeath += EnableGameOverMenu;
		Target.OnTargetDeath += EnableGameOverMenu;
	}

	private void OnDisable()
	{
		PlayerController.OnPlayerDeath -= EnableGameOverMenu;
		Target.OnTargetDeath -= EnableGameOverMenu;
	}

	public void EnableGameOverMenu()
	{
		gameOverMenu.SetActive(true);
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}
}
