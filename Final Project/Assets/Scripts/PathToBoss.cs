using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PathToBoss : MonoBehaviour {

	public GameObject player;
	public GameObject dark;
	public GameObject darkB;
	public AudioClip boss;

	
	void Start () {

	}

	void Update () {
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			darkB.SetActive(false);
		}
		return;
	}
	void OnTriggerExit2D (Collider2D other) {
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			CameraScript.bossT = false;
			SoundManager.instance.MainMusic (boss);
			Boss.showTime = true;
			Boss.attackle = true;
			dark.SetActive (true);
		} else {
			CameraScript.bossT = true;
		}
		return;
	}
}

