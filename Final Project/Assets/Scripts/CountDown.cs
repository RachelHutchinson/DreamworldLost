using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CountDown : MonoBehaviour {

	float timeRemaining = 60;
	GameObject player;
	GameObject owlCur;
	public GameObject[] owl;
	public GameObject playerI;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");
		owlCur = GameObject.FindGameObjectWithTag ("Owl");
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
			Destroy (owlCur);
			Restart();
			return;
		}
	}

	void Restart () {
		GameObject playerR =
			Instantiate (playerI, new Vector3 (3, 3, 0f), Quaternion.identity) as GameObject;
		timeRemaining = 60;
		GameObject owlR =
			Instantiate (owl[Random.Range(0,2)], new Vector3 (3, 7, 0f), Quaternion.identity) as GameObject;
		CameraScript.instance.Start ();
		CameraScript.instance.LateUpdate ();
		Player.instance.Start ();
		Player.instance.Update ();
		OnGUI ();
		Start ();
	}
}
