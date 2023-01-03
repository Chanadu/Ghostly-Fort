using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileIcons : MonoBehaviour
{
	public static ProjectileIcons current;

	public Image[] icons;
	public Sprite[] clickedSprites;
	public Sprite[] currentSprites;
	// Start is called before the first frame update
	void Start()
	{
		current = this;
	}

	public void Switched(int type)
	{
		StartCoroutine(Coroutine(type));
	}

	IEnumerator Coroutine(int type)
	{
		icons[type].sprite = clickedSprites[type];
		yield return new WaitForSeconds(0.1f);
		icons[type].sprite = currentSprites[type];
	}
}
