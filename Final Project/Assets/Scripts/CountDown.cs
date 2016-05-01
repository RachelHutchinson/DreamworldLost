using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class CountDown : MonoBehaviour {

	float timeRemaining = 300;
	GameObject player;
	public GameObject playerI;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");
		timeRemaining -= Time.deltaTime;
	}

	void OnGUI(){
		int minutes = Mathf.FloorToInt (timeRemaining / 60F);
		int seconds = Mathf.FloorToInt (timeRemaining - minutes * 60);
		string niceTime = string.Format ("{0:0}:{1:00}", minutes, seconds);

		GUI.Label (new Rect (10, 10, 250, 100), niceTime);
		if (timeRemaining > 0) {
			//countDownText.text = " "+(int)timeRemaining;
		} else {
			Destroy (player);
			Restart();
			return;
		}
	}

	void Restart () {
		GameObject playerR =
			Instantiate (playerI, new Vector3 (3, 3, 0f), Quaternion.identity) as GameObject;
		timeRemaining = 300;
		CameraScript.instance.Start ();
		CameraScript.instance.LateUpdate ();
		Player.instance.Start ();
		Player.instance.Update ();
		OnGUI ();
		Start ();
	}
}
