using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public GameObject handL;
	public GameObject handR;

	// Use this for initialization
	void Start () {
		GameObject hL =
			Instantiate (handL, new Vector3 (1, 28, 0f), Quaternion.identity) as GameObject;
		GameObject hR =
			Instantiate (handR, new Vector3 (-11, 28, 0f), Quaternion.identity) as GameObject;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
