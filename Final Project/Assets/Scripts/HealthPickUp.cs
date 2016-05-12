using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour {

	void OnTriggerStay2D (Collider2D other) {
		
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Boss.addedHealth = true;
			return;
		}
	}
}

