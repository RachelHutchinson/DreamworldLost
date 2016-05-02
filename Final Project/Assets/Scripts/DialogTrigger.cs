using UnityEngine;
using System.Collections;

public class DialogTrigger : MonoBehaviour {

	Dialogue NurseTrigger;

	// Use this for initialization
	void Start () {
		GameObject DialogBox = GameObject.FindGameObjectWithTag ("Dialog Box");
		NurseTrigger = DialogBox.GetComponent <Dialogue> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D other) {
		Debug.Log ("Hello??");
		//if space key is down
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			NurseTrigger.StartText ();
		}
		//end if
	}
}
