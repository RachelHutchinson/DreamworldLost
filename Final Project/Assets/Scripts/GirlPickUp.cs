using UnityEngine;
using System.Collections;

public class GirlPickUp : MonoBehaviour {

	void OnTriggerStay2D (Collider2D other) {

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Player.gPlayer = true;
			return;
		}
	}
}
