using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonHandler : MonoBehaviour
{

	public void LoadGame()
	{
		SceneManager.LoadScene(2);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}
	public void TutorialMenu()
	{
		SceneManager.LoadScene(1);
	}


	public void CreditMenu()
	{
		SceneManager.LoadScene(3);
	}

	public void HighScoreMenu()
	{
		SceneManager.LoadScene(4);
	}
}
