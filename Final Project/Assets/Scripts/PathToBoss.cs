using UnityEngine;
using System.Collections;

public class PathToBoss : MonoBehaviour {

	GameObject player;
	public GameObject nPlayer;
	
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void OnTriggerStay2D (Collider2D other) {
		
		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			Destroy (player);
			GameObject playerI =
				Instantiate (nPlayer, new Vector3 (6, 23, 0f), Quaternion.identity) as GameObject;
		}
		return;
	}
}
