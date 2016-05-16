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
	public AudioClip innerRoom;
	public static bool pTime = false;
	public static bool walls = false;
	public static bool reset = false;
	public static CountDown instance = null;



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
			Restart ();
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
		Boss.showTime = false;
		Boss.attackle = false;
		Boss.startAttack = false;
		Boss.addedHealth = false;
		Boss.hitP = false;
		Boss.faceAttack = false;
		CameraScript.bossT = true;
		HealthPickUp.noSaveScumbing = false;
		reset = true;
	}
}
