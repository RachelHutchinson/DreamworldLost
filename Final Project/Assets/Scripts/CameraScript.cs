using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Vector3 offset;
	public GameObject player;
	public static CameraScript instance = null;
	public static bool bossT = true;

	public void Start ()
	{	
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - player.transform.position;
		bossT = true;
		Camera.main.orthographicSize = 5;
	}

	public void Update ()
	{
		if (bossT == false) {
			Camera.main.orthographicSize = 8;
		} else {
			Camera.main.orthographicSize = 5;
		}
	}

	public void LateUpdate ()
	{ 
		player = GameObject.FindGameObjectWithTag ("Player");
		transform.position = player.transform.position + offset;
	}
		
}
	