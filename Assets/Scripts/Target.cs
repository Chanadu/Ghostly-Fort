﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
	public static event Action OnTargetDeath;
	public static Target current;
	public TMPro.TextMeshProUGUI targetText;
	public int startingTargetHealth;
	public int currentTargetHealth;

	// Start is called before the first frame update
	void Start()
	{
		current = this;
		currentTargetHealth = startingTargetHealth;
	}

	// Update is called once per frame
	void Update()
	{
		targetText.text = "Target Health: " + currentTargetHealth + "/" + startingTargetHealth;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			Enemy e = other.gameObject.GetComponent<Enemy>();
			e.attackingFort = true;
		}
	}

	public void AttackFort(int damage)
	{
		currentTargetHealth -= damage;
		if (currentTargetHealth <= 0)
		{
			currentTargetHealth = 0;
			OnTargetDeath?.Invoke();
		}
	}
}
