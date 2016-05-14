using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour {

	public static bool noSaveScumbing = false;

	void OnTriggerStay2D (Collider2D other) {

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			if (noSaveScumbing == false) {
			Boss.addedHealth = true;
			noSaveScumbing = true;
			}
		}
	}
}

