using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PathToBoss : MonoBehaviour {

	public GameObject player;
	public GameObject dark;
	public GameObject darkB;
	public GameObject coverWall;
	public AudioClip boss;
	public AudioClip boss2;


	void Start () {
		GameObject timer = GameObject.Find ("Timer");
		CountDown countDown = timer.GetComponent<CountDown> ();
		coverWall.SetActive (false);

	}

	void Update () {
		if (CountDown.walls == true) {
			coverWall.SetActive (false);
			CountDown.walls = false;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			darkB.SetActive(false);
			coverWall.SetActive (false);
		}
		return;
	}
	void OnTriggerExit2D (Collider2D other) {
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			CameraScript.bossT = false;
			if (MusicPickUp.mPickUp == true)
			{SoundManager.instance.MainMusic (boss2);
			}else{
				SoundManager.instance.MainMusic (boss);}
			Boss.showTime = true;
			Boss.attackle = true;
			Boss.checkIfDead = false;
			dark.SetActive (true);
			coverWall.SetActive (true);
		} else {
			CameraScript.bossT = true;
		}
		return;
	}
}

