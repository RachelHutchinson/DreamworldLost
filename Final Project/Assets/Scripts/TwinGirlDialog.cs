using UnityEngine;
using System.Collections;

public class TwinGirlDialog : MonoBehaviour {

	float dialogueCoolDown = 0;
	Dialogue GirlTrigger;
	int numberOfDialogLines = 0;
	public static bool GirlDialogue = false;
	public static bool playingNO = false;
	public static bool playing = false;
	bool wasGirlSpeak;
	public GameObject girlHead;
	public GameObject girl;
	public GameObject girlP;
	GameObject girlT;


	void Start () {
		GameObject DialogBox = GameObject.FindGameObjectWithTag ("Dialog Box");
		GirlTrigger = DialogBox.GetComponent <Dialogue> ();
	}
	

	void Update () 
	{
		dialogueCoolDown -= Time.deltaTime;
		girlT = GameObject.FindGameObjectWithTag ("Girl");
		if (GirlHeadFound.wasGirlFound == true){
				playing = true;
				Destroy (girlT);
				Instantiate (girl, new Vector3 (17, -15, 0f), Quaternion.identity);
				wasGirlSpeak = true;
				GirlHeadFound.wasGirlFound = false;
				numberOfDialogLines = 0;
				Instantiate (girlP, new Vector3 (4, 0, 0f), Quaternion.identity);
				TwinGirlDialog.playingNO = true;
				}

	}
	void OnTriggerStay2D (Collider2D other) {
		if (other.CompareTag ("Player") && Input.GetKeyDown (KeyCode.Space) && dialogueCoolDown <= 0) {
			if (wasGirlSpeak == false) {
				if (numberOfDialogLines == 0) {
					dialogueCoolDown = GirlTrigger.StartText ("Who are you?");
					numberOfDialogLines = 1;
					} 
				else if (numberOfDialogLines == 1) {
					dialogueCoolDown = GirlTrigger.StartText ("Are you new here?");
					numberOfDialogLines = 2;
					} 
				else if (numberOfDialogLines == 2) {
					dialogueCoolDown = GirlTrigger.StartText ("My name is Clarice, it's so nice to meet you!");
					numberOfDialogLines = 3;
					} 
				else if (numberOfDialogLines == 3) {
					dialogueCoolDown = GirlTrigger.StartText ("We're going to be best friends, I just know it.");
					numberOfDialogLines = 4;
					} 
				else if (numberOfDialogLines == 4) {
					dialogueCoolDown = GirlTrigger.StartText ("I know, why don't we play a game?");
					numberOfDialogLines = 5;
					} 
				else if (numberOfDialogLines == 5) {
					dialogueCoolDown = GirlTrigger.StartText ("I'll go hide, and you can find me.");
					numberOfDialogLines = 6;
				
					}
				else if (numberOfDialogLines == 6) {
					playing = true;
					Destroy (girlT);
					Instantiate (girlHead, new Vector3 (14, -11, 0f), Quaternion.identity);
					numberOfDialogLines = 7;
				} else if (numberOfDialogLines == 7) {
					playingNO = true;
				}
				else
				{
					GirlTrigger.StartText ("");
					numberOfDialogLines = 0;
				}
			}
		}
	}
	void OnTriggerExit2D (Collider2D other) 
	{
		GirlTrigger.StartText ("");
		numberOfDialogLines = 0;
	}
}
