using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	public float maxHealth;
	public float currentHealth;
	Transform target;
	public int enemyType = 0;
	public bool attackingFort = false;
	private readonly float timeToAttack = 2f;
	private float currentTimeToAttack = 0;
	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		target = GameObject.FindGameObjectWithTag("Player").transform;
		PlayerController.current = target.GetComponent<PlayerController>();
		GetComponent<SpriteRenderer>().sprite = PlayerController.current.numToSprite[enemyType];
	}
	private void Awake()
	{
		currentHealth = maxHealth;
	}

	private void Update()
	{
		if (attackingFort && gameObject.activeInHierarchy)
		{
			AttackFort();
		}
	}

	private void AttackFort()
	{
		if (currentTimeToAttack > 0)
		{
			currentTimeToAttack -= Time.deltaTime;
		}
		else
		{
			Target.current.currentTargetHealth -= 5;
			currentTimeToAttack = timeToAttack;
		}
	}
	public void TakeDamage(float damageAmount)
	{
		currentHealth -= damageAmount;

		if (currentHealth <= 0)
		{
			Disable();
			currentHealth = maxHealth;
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			PlayerController.current.TakeDamage(1);
		}
	}

	public void Disable()
	{
		gameObject.SetActive(false);
		currentHealth = maxHealth;
		attackingFort = false;
		currentTimeToAttack = timeToAttack;
		Score.current.score += 10;
	}
}
