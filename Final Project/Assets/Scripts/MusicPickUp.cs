using UnityEngine;
using System.Collections;

public class MusicPickUp : MonoBehaviour {

	public static bool mPickUp = false;
	public AudioClip alt;

	void OnTriggerStay2D (Collider2D other) {
		
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			mPickUp = true;
			SoundManager.instance.MainMusic (alt);
		}
	}
}
