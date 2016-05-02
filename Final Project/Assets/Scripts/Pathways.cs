using UnityEngine;
using System.Collections;

public class Pathways : MonoBehaviour {

	GameObject player;
	public GameObject nPlayer;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter(Collider other)
	{	
		if (player)
		{
			Debug.Log ("Teleporting!");
			Destroy (player);
			GameObject playerI =
				Instantiate (nPlayer, new Vector3 (8, 3, 0f), Quaternion.identity) as GameObject;
		}
		return;
	}

}
