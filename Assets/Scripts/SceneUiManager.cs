using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUiManager : MonoBehaviour
{
	public GameObject gameOverMenu;
	public static SceneUiManager current;

	private void Start()
	{
		current = this;
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

	public void ClosePauseMenu()
	{
		PauseMenuHandler.current.SetOpen(false);
		Disabler.current.EnableAll();
	}
}
