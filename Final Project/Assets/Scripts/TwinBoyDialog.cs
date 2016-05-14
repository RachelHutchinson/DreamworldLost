using UnityEngine;
using System.Collections;

public class TwinBoyDialog : MonoBehaviour {

	float dialogueCoolDown = 0;
	Dialogue BoyTrigger;
	int numberOfDialogLines = 0;
	public static bool BoyDialogue = false;
	bool wasBoyFound;
	public GameObject boyHead;
	public GameObject boy;
	GameObject boyT;

	// Use this for initialization
	void Start () {
		GameObject DialogBox = GameObject.FindGameObjectWithTag ("Dialog Box");
		BoyTrigger = DialogBox.GetComponent <Dialogue> ();
	}
	
	// Update is called once per frame
	void Update () {
		dialogueCoolDown -= Time.deltaTime;
		boyT = GameObject.FindGameObjectWithTag ("Boy");

	}
	void OnTriggerStay2D (Collider2D other) {
		if (other.CompareTag ("Player") && Input.GetKeyDown (KeyCode.Space) && dialogueCoolDown <= 0) {
			if (wasBoyFound == false) {
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
}
