using UnityEngine;
using System.Collections;

public class Pathways : MonoBehaviour {

	GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter(Collider other)
	{	
		if (other.gameObject.CompareTag("Entrance"))
		{
			Debug.Log ("Teleporting!");
			player.transform.position = new Vector3 (3f, 0f, 0f);
		}
		return;
	}

}
