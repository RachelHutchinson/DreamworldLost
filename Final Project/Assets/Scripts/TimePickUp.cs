using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimePickUp : MonoBehaviour {

	public static TimePickUp instance = null;

	void Start () {
	}

	void OnTriggerStay2D (Collider2D other) {

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			CountDown.pTime = true;
			Debug.Log ("Color");
		}
		return;
	}
}
