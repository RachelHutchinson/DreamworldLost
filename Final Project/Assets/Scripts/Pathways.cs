using UnityEngine;
using System.Collections;

public class Pathways : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (player)
		{
			player.transform.position = new Vector3 (17, 14, 0f);
			Camera.main.transform.position = new Vector3 (17, 14, 0f);
		}
	}
}
