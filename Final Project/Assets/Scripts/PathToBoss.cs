using UnityEngine;
using System.Collections;

public class PathToBoss : MonoBehaviour {

	GameObject player;
	//public GameObject dark;
	
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void OnTriggerStay2D (Collider2D other) {
		
		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			player.transform.position = new Vector3 (6, 23, 0);
			//GameObject darkO =
				//Instantiate (dark, new Vector3 (18, 2, 0f), Quaternion.identity) as GameObject;
		}
		return;
	}
}

