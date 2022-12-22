using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public Transform firePoint;
	public float fireForce;
	public void Fire()
	{
		GameObject obj = ProjectilePooler.current.GetPooledObject();
		if (obj == null)
		{
			return;
		}
		obj.transform.SetPositionAndRotation(firePoint.position, firePoint.rotation);
		obj.SetActive(true);
		obj.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
	}
}
