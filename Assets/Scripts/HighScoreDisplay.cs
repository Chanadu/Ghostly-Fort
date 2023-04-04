using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour
{
	public TMPro.TextMeshProUGUI scoreText;
	private void Update()
	{
		try
		{
			scoreText.text = "your  current  high  score  is: \n" + Score.current.highScore;
		}
		catch (System.Exception)
		{
			scoreText.text = "play  a  round  of  a  game  to  get  a  high  score.";
		}
	}
}
