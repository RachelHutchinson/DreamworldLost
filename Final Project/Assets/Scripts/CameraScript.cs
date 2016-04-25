﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Vector3 offset;
	public GameObject player;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - player.transform.position;
	}

	void LateUpdate ()
	{ 
		transform.position = player.transform.position + offset;
	}
		
}
	