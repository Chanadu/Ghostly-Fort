using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuHandler : MonoBehaviour
{
	public static PauseMenuHandler current;
	public static event Action OnPause;
	public GameObject menu;
	public bool open = false;
	private void Start()
	{
		current = this;
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SetOpen(!open);
		}
	}

	public void SetOpen(bool b)
	{
		open = b;
		menu.SetActive(open);
		if (open)
		{
			Disabler.current.DisableAll();
		}
		else
		{
			Disabler.current.EnableAll();
		}
	}
}
