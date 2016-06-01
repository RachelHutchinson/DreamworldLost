using UnityEngine;
using System.Collections;

public class GirlHeadFound : MonoBehaviour {

	float dialogueCoolDown = 0;
	Dialogue GirlHeadTrigger;
	int numberOfDialogLines = 0;
	public static bool wasGirlFound;

	// Use this for initialization
	void Start () {
		GameObject DialogBox = GameObject.FindGameObjectWithTag ("Dialog Box");
		GirlHeadTrigger = DialogBox.GetComponent <Dialogue> ();
	}
	
	// Update is called once per frame
	void Update () {
		dialogueCoolDown -= Time.deltaTime;
	}
	void OnTriggerStay2D (Collider2D other) {
		if (other.CompareTag ("Player") && Input.GetKeyDown (KeyCode.Space) && dialogueCoolDown <= 0) {
			if (wasGirlFound == false) {
				if (numberOfDialogLines == 0) 
					{
					dialogueCoolDown = GirlHeadTrigger.StartText ("...");
					numberOfDialogLines = 1;
					} 
				else if (numberOfDialogLines == 1) {
					dialogueCoolDown = GirlHeadTrigger.StartText ("Oh...");
					numberOfDialogLines = 2;
				} 
				else if (numberOfDialogLines == 2) {
					dialogueCoolDown = GirlHeadTrigger.StartText ("You found me, I guess....");
					numberOfDialogLines = 3;
				} 
				else if (numberOfDialogLines == 3) {
					dialogueCoolDown = GirlHeadTrigger.StartText ("Since you are the winner, I'll put my toy chest in your room.");
					numberOfDialogLines = 4;
				} 
				else if (numberOfDialogLines == 4) {
					dialogueCoolDown = GirlHeadTrigger.StartText (" h n s  o  P a i g  y G m .");
					numberOfDialogLines = 5;
				} 
				else 
				{
					GirlHeadTrigger.StartText ("");
					numberOfDialogLines = 0;
					wasGirlFound = true;
				}
			}
		}
	}
	void OnTriggerExit2D (Collider2D other) 
	{
		GirlHeadTrigger.StartText ("");
		numberOfDialogLines = 0;
	}
}
