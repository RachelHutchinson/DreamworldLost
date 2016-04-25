using UnityEngine;
using System.Collections;

public class Pathways : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (player)
		{
			player.transform.position = new Vector3 (17, 14, 0f);
			Debug.Log ("Transform!");
		}
	}
}
