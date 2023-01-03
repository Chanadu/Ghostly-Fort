using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	public float maxHealth;
	public float currentHealth;
	private PlayerController player;
	public Transform target;
	private float moveSpeed;
	public Vector2 moveDirection;
	private Rigidbody2D rb;
	public int enemyType = 0;
	public bool attackingFort = false;
	private readonly float timeToAttack = 1f;
	private float currentTimeToAttack = 0;
	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		player = PlayerController.current;
		target = GameObject.FindGameObjectWithTag("Target").transform;
		switch (enemyType)
		{
			case 0:
				moveSpeed = Random.Range(1f, 2f);
				break;
			case 1:
				moveSpeed = Random.Range(2f, 3f);
				break;
			case 2:
				moveSpeed = Random.Range(3f, 4f);
				break;
		}
		moveSpeed = Random.Range(2f, 4f);
	}
	private void Awake()
	{
		currentHealth = maxHealth;
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (attackingFort && gameObject.activeInHierarchy)
		{
			AttackFort();
		}

		if (player && target)
		{
			if (Vector2.Distance(transform.position, player.gameObject.transform.position) < Vector2.Distance(transform.position, target.position))
			{
				Vector3 direction = (player.gameObject.transform.position - transform.position).normalized;
				//float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
				//rb.rotation = angle;
				moveDirection = direction;
			}
			else
			{
				Vector3 direction = (target.position - transform.position).normalized;
				//float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
				//rb.rotation = angle;
				moveDirection = direction;
			}

			if (moveDirection.x < 0)
			{
				GetComponent<SpriteRenderer>().flipX = true;

			}
			else
			{
				GetComponent<SpriteRenderer>().flipX = false;
			}
		}
	}

	private void FixedUpdate()
	{
		if (player)
		{
			rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
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
			target.gameObject.GetComponent<Target>().currentTargetHealth -= 5;
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
