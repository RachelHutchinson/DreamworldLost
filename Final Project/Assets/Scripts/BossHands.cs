using UnityEngine;
using System.Collections;

public class BossHands : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collision) 
	{
		if (collision.gameObject.tag == "Player") {
			Boss.hit = true;
		}
	}
}
