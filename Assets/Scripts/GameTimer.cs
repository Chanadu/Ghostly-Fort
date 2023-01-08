using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
	public static GameTimer current;
	public float currentTime;
	public TMPro.TextMeshProUGUI timerObject;
	int min = 0;
	int sec = 0;
	int milli = 0;

	bool stop = false;
	private void Start()
	{
		current = this;
	}

	void Update()
	{
		if (!stop)
		{
			currentTime += Time.deltaTime;

			double timerTime = Math.Round(currentTime, 2);


			min = (int)Math.Floor(timerTime / 60);
			string SMin = min.ToString();
			timerTime -= min * 60;
			sec = (int)Math.Floor(timerTime);
			string SSec = sec.ToString();
			timerTime -= sec;
			milli = (int)Math.Floor(timerTime * 100);
			string SMilli = milli.ToString();

			if (min < 10)
			{
				SMin = "0" + SMin;
			}
			if (sec < 10)
			{
				SSec = "0" + SSec;
			}
			if (milli < 10)
			{
				SMilli = "0" + SMilli;
			}

			timerObject.text = SMin + ":" + SSec + ":" + SMilli;
		}

	}

	public int[] GetTime()
	{
		int[] arr = new int[] { min, sec };
		return arr;
	}

	public void StopTime()
	{
		stop = true;
	}

	public void StartTime()
	{
		stop = false;
	}
}
