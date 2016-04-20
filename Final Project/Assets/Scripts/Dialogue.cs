using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

	private Text dialogue;
	public string[] dialogueStrings;
	public float secondsBetweenCharacters = 0.4f; 


	// Use this for initialization
	void Start () {
		dialogue = GetComponent<Text>();
		dialogue.text = "";
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			StartCoroutine (DisplayString (dialogueStrings [0]));
		}
	}

	private IEnumerator DisplayString(string stringToDisplay)
	{
		int stringLength = stringToDisplay.Length;
		int currentCharacterIndex = 0;

		dialogue.text = "";

		while (currentCharacterIndex < stringLength) {
			dialogue.text += stringToDisplay [currentCharacterIndex];
			currentCharacterIndex++;

			if (currentCharacterIndex < stringLength) 
			{
				yield return new WaitForSeconds (secondsBetweenCharacters);

			} 
			else 
			{
				break;
			}
		}
		dialogue.text = "";
	}
}
