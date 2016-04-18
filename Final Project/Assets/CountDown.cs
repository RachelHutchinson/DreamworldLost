using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class CountDown : MonoBehaviour {
	float timeRemaining = 60;
	public Text countDownText;
	public Text loseText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeRemaining -= Time.deltaTime;
	}

	void OnGUI(){
		int minutes = Mathf.FloorToInt (timeRemaining / 60F);
		int seconds = Mathf.FloorToInt (timeRemaining - minutes * 60);
		string niceTime = string.Format ("{0:0}:{1:00}", minutes, seconds);

		GUI.Label (new Rect (10, 10, 250, 100), niceTime);

		if (timeRemaining > 0) {
			countDownText.text = "Time Remaining: "+(int)timeRemaining;
		} else {
			countDownText.text = "Time's up!";
			loseText.text = "Game Over !";
			Time.timeScale = 0; 
		}
	}
}
