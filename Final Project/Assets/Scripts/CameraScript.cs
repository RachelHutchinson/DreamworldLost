using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Vector3 offset;
	public GameObject player;
	public static CameraScript instance = null;
	public static bool bossT = true;

	public void Start ()
	{	
		bossT = true;
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - player.transform.position;
	}

	public void LateUpdate ()
	{ 
		player = GameObject.FindGameObjectWithTag ("Player");
		transform.position = player.transform.position + offset;
		if (bossT == false) {
			Camera.main.orthographicSize = 8;
		} else {
			Camera.main.orthographicSize = 5;
		}
			
	}
		
}
	