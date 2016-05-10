using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PathToBoss : MonoBehaviour {

	GameObject player;
	public GameObject dark;
	public GameObject darkB;
	public AudioClip boss;

	
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");
		darkB = GameObject.FindGameObjectWithTag ("DarknessB");
	}
	
	void OnTriggerStay2D (Collider2D other) {
		
		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			Destroy (darkB);
			darkB = GameObject.FindGameObjectWithTag ("DarknessB");
			Destroy (darkB);
			CameraScript.bossT = false;
			player.transform.position = new Vector3 (6, 23, 0);
			GameObject darkO =
				Instantiate (dark, new Vector3 (18, 2, 0f), Quaternion.identity) as GameObject;
			SoundManager.instance.MainMusic (boss);
			Boss.showTime = true;
		}
		return;
	}
}

