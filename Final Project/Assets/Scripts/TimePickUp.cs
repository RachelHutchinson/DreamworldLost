using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TimePickUp : MonoBehaviour {

	void OnTriggerStay2D (Collider2D other) {

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			CountDown.pTime = true;
			return;
		}
	}
}
