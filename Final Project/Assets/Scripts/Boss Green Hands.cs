using UnityEngine;
using System.Collections;

public class BossGreenHands : MonoBehaviour {

	private Animator animator;

	
	void Start () {
		animator = GetComponent <Animator> ();
	}


	void OnTriggerEnter2D (Collider2D collision) 
	{
		if (collision.gameObject.tag == "Player") {
			Boss.hit = true;
			Debug.Log ("Hit!");
		}
	}

}
