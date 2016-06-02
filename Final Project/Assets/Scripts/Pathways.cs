using UnityEngine;
using System.Collections;

public class Pathways : MonoBehaviour {

	public GameObject player;
	public GameObject darkI;
	public GameObject darkO;
	public GameObject coverWall;
	public AudioClip outerRoom;
	public AudioClip outerRoom2;

	public int room;
	//x and y of the wall of the room you just left
	//wall

	enum Direction {
		Left,
		Right
	}

	Direction dir;

	void Start () {
		GameObject timer = GameObject.Find ("Timer");
		CountDown countDown = timer.GetComponent<CountDown> ();
		coverWall.SetActive (false);
	}

	void Update () {
		if (CountDown.walls == true) {
			coverWall.SetActive (false);
			CountDown.walls = false;
		}

		if (TwinGirlDialog.playing == true) {
			HideandSeek ();
			TwinGirlDialog.playing = false;
		}
		if (TwinGirlDialog.playingNO == true) {
			canSee ();
			TwinGirlDialog.playingNO = false;
		}

		int horizontal = (int)(Input.GetAxisRaw ("Horizontal"));

		if (horizontal > 0) {
			dir = Direction.Right;
		} else if (horizontal < 0) {
			dir = Direction.Left;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		darkO.SetActive(false);
		darkI.SetActive(false);
	}

	public void HideandSeek () {
		darkO.SetActive (true);
	}

	public void canSee () {
		darkO.SetActive (false);
	}

	void OnTriggerExit2D (Collider2D other) {
		
		if (dir == Direction.Right) {
			darkI.SetActive (true);
			if (MusicPickUp.mPickUp == true)
			{SoundManager.instance.MainMusic (outerRoom2);
			} else {
			SoundManager.instance.MainMusic (outerRoom);
			}
			coverWall.SetActive (true);
		} else {
			darkO.SetActive (true);
		}
	}		

}
