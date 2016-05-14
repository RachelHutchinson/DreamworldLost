using UnityEngine;
using System.Collections;

public class BoyHeadFound : MonoBehaviour {

	float dialogueCoolDown = 0;
	Dialogue BoyHeadTrigger;
	int numberOfDialogLines = 0;
	public static bool wasBoyFound;


	// Use this for initialization
	void Start () {
		GameObject DialogBox = GameObject.FindGameObjectWithTag ("Dialog Box");
		BoyHeadTrigger = DialogBox.GetComponent <Dialogue> ();
	}
	
	// Update is called once per frame
	void Update () {
		dialogueCoolDown -= Time.deltaTime;
	}
	void OnTriggerStay2D (Collider2D other) {
		if (other.CompareTag ("Player") && Input.GetKeyDown (KeyCode.Space) && dialogueCoolDown <= 0) {
			if (wasBoyFound == false) {
				if (numberOfDialogLines == 0) {
					dialogueCoolDown = BoyHeadTrigger.StartText ("You found me!");
					numberOfDialogLines = 1;
				} 
				else if (numberOfDialogLines == 1) {
					dialogueCoolDown = BoyHeadTrigger.StartText ("I can't believe you managed to find your best buddy so quickly.");
					numberOfDialogLines = 2;
				} 
				else if (numberOfDialogLines == 2) {
					dialogueCoolDown = BoyHeadTrigger.StartText ("I guess Clancy's secret hiding spot was no match for you.");
					numberOfDialogLines = 3;
				} 
				else if (numberOfDialogLines == 3) {
					dialogueCoolDown = BoyHeadTrigger.StartText ("Since you are the winner, I'll put my toy chest in your room.");
					numberOfDialogLines = 4;
				} 
				else if (numberOfDialogLines == 4) {
					dialogueCoolDown = BoyHeadTrigger.StartText ("T a k  F r  l y n  M   a e");
					numberOfDialogLines = 5;
				} 
				else 
				{
					BoyHeadTrigger.StartText ("");
					numberOfDialogLines = 0;
					wasBoyFound = true;
				}
			}
		}
	}
}
