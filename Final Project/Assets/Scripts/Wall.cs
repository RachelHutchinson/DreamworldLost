using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	public Sprite dragSprite;
	public int hp = 4;

	private SpriteRenderer spriteRenderer;

	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	public void DamageWall (int loss)
	{
		spriteRenderer.sprite = dragSprite;
		hp -= loss;
		if (hp <= 0)
			gameObject.SetActive (false);
	}
}

