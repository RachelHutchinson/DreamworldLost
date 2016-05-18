using UnityEngine;
using System.Collections;

public class BossHandsBlue : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collision) 
	{
		if (collision.gameObject.tag == "Player") {
			Boss.hit = true;
			Boss.hitBoss = true;
		}
	}
}
