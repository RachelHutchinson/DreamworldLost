using UnityEngine;
using System.Collections;

public class MusicianDialog : MonoBehaviour {

	float dialogueCoolDown = 0;
	Dialogue MusicianTrigger;
	int numberOfDialogLines = 0;
	public static bool MusicianDialogue = false;
	bool isDialogOneDone;
	bool isDialogTwoDone;
	bool isDialogThreeDone;

	// Use this for initialization
	void Start () {
			GameObject DialogBox = GameObject.FindGameObjectWithTag ("Dialog Box");
			MusicianTrigger = DialogBox.GetComponent <Dialogue> ();
	}
	
	// Update is called once per frame
	void Update () {
			dialogueCoolDown -= Time.deltaTime;
	}
		void OnTriggerStay2D (Collider2D other) {
		if (other.CompareTag ("Player") && Input.GetKeyDown (KeyCode.Space) && dialogueCoolDown <= 0) {
			if (isDialogOneDone == false) {
				if (numberOfDialogLines == 0) 
					{
					dialogueCoolDown = MusicianTrigger.StartText ("Ah, a child? I've never seen you around before.");
					numberOfDialogLines = 1;
					} 
					else if (numberOfDialogLines == 1) 
					{
					dialogueCoolDown = MusicianTrigger.StartText ("Oh, child, I'm in despair. Would you please lend an ear to these terrible turn of events?");
					numberOfDialogLines = 2;
					}
					else if (numberOfDialogLines == 2) 
					{
					dialogueCoolDown = MusicianTrigger.StartText ("I was but a happy musician not too long ago");
					numberOfDialogLines = 3;
					}
			}
		}
	}
}
