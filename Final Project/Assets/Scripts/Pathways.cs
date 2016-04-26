using UnityEngine;
using System.Collections;

public class Pathways : MonoBehaviour {

	GameObject player;
	GameObject entrance;
	GameObject last;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		entrance = GameObject.FindGameObjectWithTag ("Entrance");
		last = GameObject.FindGameObjectWithTag ("Exit");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (last == entrance)
			return;
	}

	void OnTriggerExit ()
	{
		if (last == entrance)
			last = null;
	}

	void OnTriggerEnter (Collider Portal)
	{
		if (hit.gameObject.player)
			player.transform.position = last.transform.position;
			Debug.Log ("Transform!");
		}
	}
