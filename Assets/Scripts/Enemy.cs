using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float maxHealth = 3f;
	private float currentHealth;

	public float moveSpeed = 5f;
	Rigidbody2D rb;
	Transform target;

	PlayerController playerController;
	private Vector2 moveDirection;

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		target = GameObject.FindGameObjectWithTag("Player").transform;
		playerController = target.GetComponent<PlayerController>();
	}

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (target)
		{
			Vector3 direction = (target.position - transform.position).normalized;
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
			rb.rotation = angle;
			moveDirection = direction;
		}
	}

	private void FixedUpdate()
	{
		if (target)
		{
			rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
		}
	}
	public void TakeDamage(float damageAmount)
	{
		currentHealth -= damageAmount;

		if (currentHealth <= 0)
		{
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			playerController.TakeDamage(1);
		}
	}
}
