using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Vector3 offset;
	public GameObject player;
	public static CameraScript instance = null;

	public void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - player.transform.position;
	}

	public void LateUpdate ()
	{ 
		player = GameObject.FindGameObjectWithTag ("Player");
		transform.position = player.transform.position + offset;
	}
		
}
	