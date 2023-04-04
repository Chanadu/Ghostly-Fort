using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
	private void Start()
	{
		Score.current.score = 0;
	}
	public TMPro.TextMeshProUGUI scoreText;
	private void Update()
	{
		scoreText.text = "Score: " + Score.current.score;
	}
}
