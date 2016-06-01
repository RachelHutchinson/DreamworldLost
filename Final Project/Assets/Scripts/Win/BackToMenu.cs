using UnityEngine;
using System.Collections;

public class BackToMenu : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D collision) 
	{
		if (collision.gameObject.tag == "Player") {
			Application.LoadLevel (0);

		}
	}
}
