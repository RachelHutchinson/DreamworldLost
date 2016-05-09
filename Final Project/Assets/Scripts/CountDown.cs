using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CountDown : MonoBehaviour {

	float timeRemaining = 60;
	GameObject player;
	GameObject owlCur;
	GameObject pickT;
	GameObject darkI;
	GameObject darkO;
	GameObject darkB;
	public GameObject dark1;
	public GameObject dark2;
	public GameObject[] owl;
	public GameObject playerI;
	public GameObject timePick;
	public AudioClip innerRoom;
	public static bool pTime = false;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");
		owlCur = GameObject.FindGameObjectWithTag ("Owl");
		pickT = GameObject.FindGameObjectWithTag ("Time");
		timeRemaining -= Time.deltaTime;
	}

	public void OnGUI(){

		int minutes = Mathf.FloorToInt (timeRemaining / 60F);
		int seconds = Mathf.FloorToInt (timeRemaining - minutes * 60);
		string niceTime = string.Format ("{0:0}:{1:00}", minutes, seconds);
		if (timeRemaining > 0) {
		} else {
			Destroy (player);
			Restart();
		}
		if (pTime == true) {
			GUI.Label (new Rect (10, 10, 250, 100), niceTime);
		}
	}
		

	void Restart () {
		Destroy (owlCur);
		Destroy (timePick);
		darkI = GameObject.FindGameObjectWithTag ("DarknessI");
		darkO = GameObject.FindGameObjectWithTag ("DarknessO");
		darkB = GameObject.FindGameObjectWithTag ("DarknessB");
		Destroy (darkO);
		Destroy (darkI);
		Destroy (darkB);
		//SoundManager.instance.musicSource.Play (innerRoom);
		GameObject darkL =
			Instantiate (dark1, new Vector3 (18, 2, 0f), Quaternion.identity) as GameObject;
		GameObject darkM =
			Instantiate (dark2, new Vector3 (-5, 22, 0f), Quaternion.identity) as GameObject;
		pTime = false;
		GameObject playerR =
			Instantiate (playerI, new Vector3 (3, 3, 0f), Quaternion.identity) as GameObject;
		timeRemaining = 60;
		GameObject owlR =
			Instantiate (owl[Random.Range(0,2)], new Vector3 (3, 7, 0f), Quaternion.identity) as GameObject;
		GameObject timeP =
			Instantiate (timePick, new Vector3 (2, 7, 0f), Quaternion.identity) as GameObject;
		Player.instance.Start ();
		Player.instance.Update ();
		OnGUI ();
		Start ();
		CameraScript.instance.Start ();
		CameraScript.instance.LateUpdate ();
	}
}
