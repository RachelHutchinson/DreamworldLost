using UnityEngine;
using System.Collections;

public class Pathways : MonoBehaviour {

	public GameObject player;
	public GameObject darkI;
	public GameObject darkO;

	public AudioClip outerRoom;
	public int room;
	//x and y of the wall of the room you just left
	//wall

	void Start () {
	}

	void Update () {
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) 
		{
			darkO.SetActive(false);
			darkI.SetActive(false);

			SoundManager.instance.MainMusic (outerRoom);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		
		if (Input.GetKey (KeyCode.RightArrow)) {
			//make wall appear
			darkI.SetActive (true);
			SoundManager.instance.MainMusic (outerRoom);
		} else {
			darkO.SetActive (true);
		}
	}		

}
