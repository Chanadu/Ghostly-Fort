using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	private static Score _current;
	public static Score current
	{
		get
		{
			if (!_current)
			{
				_current = new GameObject().AddComponent<Score>();
				DontDestroyOnLoad(_current.gameObject);
			}
			return _current;
		}
	}


	public int score = 0;
	public int highScore = 0;
	public void IncreaseScore(int s)
	{
		score += s;
		if (score > highScore)
		{
			highScore = score;
			print("New HighScore!" + " Score: " + score);
		}
		else
		{
			print("new Score" + " Score: " + score);
		}
	}
}
