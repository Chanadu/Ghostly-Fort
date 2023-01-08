using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
	public TMPro.TextMeshProUGUI finalScore;

	private void OnEnable()
	{
		StartCoroutine(CountUpToTargetScore());
	}

	IEnumerator CountUpToTargetScore()
	{
		float currentDisplayScore = 0;
		int s = Score.current.score + GameTimer.current.GetTime()[0] * 60 + GameTimer.current.GetTime()[1];
		if (currentDisplayScore >= s || s == 0)
		{
			finalScore.text = "Final Score: 0";
		}
		int countSpeed =
					s < 250 ? 1
					: s < 750 ? 5
					: 10;

		while (currentDisplayScore < s)
		{
			currentDisplayScore += countSpeed; // or whatever to get the speed you like
			currentDisplayScore = Mathf.Clamp(currentDisplayScore, 0f, s);
			finalScore.text = "Final Score: " + currentDisplayScore.ToString();
			yield return null;
		}
	}

}
