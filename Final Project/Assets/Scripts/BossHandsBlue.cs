using UnityEngine;
using System.Collections;

public class BossHandsBlue : MonoBehaviour {

	private Animator animator;


	void Start ()
	{
		animator = GetComponent<Animator> ();

	}

	void OnTriggerEnter2D (Collider2D collision) 
	{
		if (collision.gameObject.tag == "Player") {
			animator.SetTrigger ("hit");
			Boss.hitBoss = true;
		}
	}
}
