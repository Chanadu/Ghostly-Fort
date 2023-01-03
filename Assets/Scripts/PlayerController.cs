using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public static PlayerController current;
	public Camera sceneCamera;
	public float moveSpeed;
	public Rigidbody2D rb;
	public Weapon weapon;
	public Sprite[] weaponSprites;

	public float health, maxHealth;
	public float damageTickCooldown;
	private float currentDamageCooldown;
	private Vector2 moveDirection;
	private Vector2 mousePosition;

	public IDictionary<int, Sprite> numToSprite;
	public int currentWeapon = 0;
	public SpriteRenderer weaponSpriteRenderer;
	void Start()
	{
		current = this;
		health = maxHealth;
		numToSprite = new Dictionary<int, Sprite>()
		{
			{0, weaponSprites[0]},
			{1, weaponSprites[1]},
			{2, weaponSprites[2]},
		};

		weaponSpriteRenderer.sprite = numToSprite[currentWeapon];
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
		if (Input.GetMouseButtonDown(1))
		{
			currentWeapon++;
			if (currentWeapon >= 3)
			{
				currentWeapon = 0;
			}
			weaponSpriteRenderer.sprite = numToSprite[currentWeapon];
			ProjectileIcons.current.Switched(currentWeapon);
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			currentWeapon = 0;
			weaponSpriteRenderer.sprite = numToSprite[currentWeapon];
			ProjectileIcons.current.Switched(currentWeapon);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			currentWeapon = 1;
			weaponSpriteRenderer.sprite = numToSprite[currentWeapon];
			ProjectileIcons.current.Switched(currentWeapon);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			currentWeapon = 2;
			weaponSpriteRenderer.sprite = numToSprite[currentWeapon];
			ProjectileIcons.current.Switched(currentWeapon);
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
