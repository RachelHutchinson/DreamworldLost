using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CountDown : MonoBehaviour {

	public float timeRemaining = 180;
	GameObject player;
	GameObject owlCur;
	GameObject pickT;
	public GameObject darkI;
	public GameObject darkO;
	public GameObject darkB;
	public GameObject dark1;
	public GameObject dark2;
	public GameObject[] owl;
	public GameObject playerI;
	public GameObject timePick;
	public GameObject LPick;
	public AudioClip innerRoom;
	public static bool timeIsUp = false;
	public static bool pTime = false;
	public static bool walls = false;
	public static bool reset = false;
	public static CountDown instance = null;



	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

	}
	
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
			timeIsUp = true;
		}
		if (pTime == true) {
			GUI.Label (new Rect (10, 10, 250, 100), niceTime);
		}
	}
		
		
	public void Restart () {
		OwlDialog.didPlayerDieAtBoss = true;
		walls = true;
		Destroy (player);
		player = Instantiate(playerI, new Vector3 (3, 3, 0f), Quaternion.identity) as GameObject;
		Player playerScript = player.GetComponent<Player> ();
		playerScript.Start ();
		Destroy (owlCur);
		Destroy (timePick);
		darkI.SetActive(false);
		darkO.SetActive(true);
		darkB.SetActive(true);
		MusicPickUp.mPickUp = false;
		SoundManager.instance.MainMusic (innerRoom);
		pTime = false;
		timeRemaining = 180;
		GameObject owlR =
			Instantiate (owl [Random.Range (0, 2)], new Vector3 (3, 7, 0f), Quaternion.identity) as GameObject;
		GameObject timeP =
			Instantiate (timePick, new Vector3 (2, 7, 0f), Quaternion.identity) as GameObject;
		if (LibrarianDialog.setForPick == true) {
			Instantiate (LPick, new Vector3 (0, 5, 0f), Quaternion.identity);
			LibrarianDialog.silenceInTheLibrary = true;
		}
		CameraScript.bossT = true;
		HealthPickUp.noSaveScumbing = false;
		reset = true;
	}
}
