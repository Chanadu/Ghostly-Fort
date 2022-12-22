using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Camera sceneCamera;
	public float moveSpeed;
	public Rigidbody2D rb;
	public Weapon weapon;

	public float health, maxHealth;
	public float damageTickCooldown;
	private float currentDamageCooldown;
	private Vector2 moveDirection;
	private Vector2 mousePosition;


	private void Start()
	{
		health = maxHealth;
	}
	void Update()
	{
		ProcessInputs();
		TickDamageCooldown();
	}

	void FixedUpdate()
	{
		Move();
	}

	void ProcessInputs()
	{
		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");

		if (Input.GetMouseButtonDown(0))
		{
			weapon.Fire();
		}
		moveDirection = new Vector2(moveX, moveY).normalized;
		mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
	}

	void Move()
	{
		rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
		Vector2 aimDirection = mousePosition - rb.position;
		float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;

		rb.rotation = aimAngle;
	}

	public void TakeDamage(int damageAmount)
	{
		if (currentDamageCooldown <= 0)
		{
			health -= damageAmount;
			currentDamageCooldown = damageTickCooldown;
		}

	}

	private void TickDamageCooldown()
	{
		if (currentDamageCooldown > 0)
		{
			currentDamageCooldown -= Time.deltaTime;
		}
	}
}
