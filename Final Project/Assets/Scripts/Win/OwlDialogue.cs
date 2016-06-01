using UnityEngine;
using System.Collections;

public class OwlDialogue : MonoBehaviour {

	float dialogueCoolDown = 0;
	Dialogue owlTrigger;
	int numberOfDialogLines = 0;

	// Use this for initialization
	void Start () {
		GameObject DialogBox = GameObject.FindGameObjectWithTag ("Dialog Box");
		owlTrigger = DialogBox.GetComponent <Dialogue> ();
	}
	
	// Update is called once per frame
	void Update () {
		dialogueCoolDown -= Time.deltaTime;
	}
	void OnTriggerStay2D (Collider2D other) {
		
		if (other.CompareTag ("Player") && Input.GetKeyDown (KeyCode.Space) && dialogueCoolDown <= 0) {
			if (numberOfDialogLines == 0) {
				dialogueCoolDown = owlTrigger.StartText ("Ah, I see you've awakened once more.");
				numberOfDialogLines = 1;
			} else if (numberOfDialogLines == 1) {
				dialogueCoolDown = owlTrigger.StartText ("This time it's to reality.");
				numberOfDialogLines = 2;
			} else if (numberOfDialogLines == 2) {
				dialogueCoolDown = owlTrigger.StartText ("It seems you finally understood that sometimes it's nice to explore a little.");
				numberOfDialogLines = 3;
			} else if (numberOfDialogLines == 3) {
				dialogueCoolDown = owlTrigger.StartText ("Go now, run along to your parents.");
				numberOfDialogLines = 4;
			} else if (numberOfDialogLines == 4) {
				dialogueCoolDown = owlTrigger.StartText ("See you another night.");
				numberOfDialogLines = 5;
			} else {
				owlTrigger.StartText ("");
				numberOfDialogLines = 0;
			}
		}
	}
	void OnTriggerExit2D (Collider2D other) 
	{
		owlTrigger.StartText ("");
		numberOfDialogLines = 0;
	}
}
