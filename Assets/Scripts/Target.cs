using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
	public static Target current;
	public Text targetText;
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

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			Enemy e = other.gameObject.GetComponent<Enemy>();
			e.attackingFort = true;
		}
	}
}
