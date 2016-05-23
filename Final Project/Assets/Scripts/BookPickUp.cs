using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BookPickUp : MonoBehaviour {

	public static bool advice = false;
	Text librarianText;
	double coolDownTime = 3.5;
	double currentCoolDownTime = 0;

	void Start() {
		librarianText = GameObject.Find ("Helpful Hint").GetComponent<Text>();
	}

	void OnTriggerStay2D (Collider2D other) {
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			advice = true;
			Debug.Log ("Let me work");
		}
	}


	void Update ()
	{
		if (currentCoolDownTime > 0) 
		{
			currentCoolDownTime = currentCoolDownTime - Time.deltaTime;
			return;
		} 
		if (currentCoolDownTime < 0) {
			librarianText.text = " ";
		}


		if (Input.GetKeyDown (KeyCode.H) && advice == true) {
			if (Boss.faceAttack == true) { 
				librarianText.text = "Start moving towards the middle if you want to survive!";
				currentCoolDownTime = coolDownTime;

			} else if (Boss.startAttack == true){
				librarianText.text = "White hands will suck out 20 and so will the faces!";
				currentCoolDownTime = coolDownTime;
		
			} else if (Boss.startDefence == true) {
				librarianText.text = "Charge at the blue hands to give them a taste of his own medicine!";
				currentCoolDownTime = coolDownTime;

			} else if (Boss.purpleAttack == true) {
				librarianText.text = "Avoid purple at all costs or you will DIE!";
				currentCoolDownTime = coolDownTime;
			
			} else {
				librarianText.text = "Why do you need my help?";
				currentCoolDownTime = coolDownTime;
			}

			advice = false; 
		}
	}

}
