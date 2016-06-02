using UnityEngine;
using System.Collections;

public class TwinBoyDialog : MonoBehaviour {

	float dialogueCoolDown = 0;
	Dialogue BoyTrigger;
	int numberOfDialogLines = 0;
	public static bool BoyDialogue = false;
	bool wasBoySpeak;
	public GameObject boyHead;
	public GameObject boy;
	public GameObject boyP;
	GameObject boyT;

	void Start () {
		GameObject DialogBox = GameObject.FindGameObjectWithTag ("Dialog Box");
		BoyTrigger = DialogBox.GetComponent <Dialogue> ();
	}
	
	void Update () {
		dialogueCoolDown -= Time.deltaTime;
		boyT = GameObject.FindGameObjectWithTag ("Boy");
		if (BoyHeadFound.wasBoyFound == true){
			TwinGirlDialog.playing = true;
			Destroy (boyT);
			Instantiate (boy, new Vector3 (16, -15, 0f), Quaternion.identity);
			TwinGirlDialog.playingNO = true;
			numberOfDialogLines = 0;
			wasBoySpeak = true;
			Instantiate (boyP, new Vector3 (3, 0, 0f), Quaternion.identity);
			BoyHeadFound.wasBoyFound = false;
		}

	}
	void OnTriggerStay2D (Collider2D other) {
		if (other.CompareTag ("Player") && Input.GetKeyDown (KeyCode.Space)) {
			if (dialogueCoolDown > 0)
			{
				BoyTrigger.FinishText();
				return;
			}
			if (wasBoySpeak == false) {
				if (numberOfDialogLines == 0) {
					dialogueCoolDown = BoyTrigger.StartText ("...");
					numberOfDialogLines = 1;
					} 
				else if (numberOfDialogLines == 1) {
					dialogueCoolDown = BoyTrigger.StartText ("... What?");
					numberOfDialogLines = 2;
					} 
				else if (numberOfDialogLines == 2) {
					dialogueCoolDown = BoyTrigger.StartText ("You want to play a game?");
					numberOfDialogLines = 3;
					} 
				else if (numberOfDialogLines == 3) {
					dialogueCoolDown = BoyTrigger.StartText ("Okay... Then...");
					numberOfDialogLines = 4;
					} 
				else if (numberOfDialogLines == 4) {
					dialogueCoolDown = BoyTrigger.StartText ("I'll go hide, and you can find me.");
					numberOfDialogLines = 5;
					} 
				else if (numberOfDialogLines == 5) {
					TwinGirlDialog.playing = true;
					Destroy (boyT);
					Instantiate (boyHead, new Vector3 (16, 18, 0f), Quaternion.identity);
					numberOfDialogLines = 6;
				} else if (numberOfDialogLines == 6) {
					TwinGirlDialog.playingNO = true;
				}
				else {
						BoyTrigger.StartText ("");
						numberOfDialogLines = 0;
					}
				}
			}
		}
	void OnTriggerExit2D (Collider2D other) 
	{
		BoyTrigger.StopText();
		BoyTrigger.StartText ("");
		numberOfDialogLines = 0;
	}
	}
