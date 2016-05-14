using UnityEngine;
using System.Collections;

public class BoyPickUp : MonoBehaviour {

	void OnTriggerStay2D (Collider2D other) {

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Player.bPlayer = true;
			return;
		}
	}
}
