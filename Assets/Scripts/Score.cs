using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public static Score current;
	public Text scoreText;
	public int score;
	// Start is called before the first frame update
	void Start()
	{
		current = this;
	}

	private void Update()
	{
		scoreText.text = "Score: " + score;
	}
}
