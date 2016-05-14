using UnityEngine;
using System.Collections;

public class MusicianDialog : MonoBehaviour {

	float dialogueCoolDown = 0;
	Dialogue MusicianTrigger;
	int numberOfDialogLines = 0;
	public static bool MusicianDialogue = false;
	public static bool musicPick = false;
	bool isDialogOneDone;
	bool isDialogTwoDone;
	bool isDialogThreeDone;
	bool rachelIsMagic;
	public AudioClip ohThe;
	public AudioClip ohTheDrama;
	public AudioClip ofTheDramatic;
	public AudioClip backtonorm;

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
					SoundManager.instance.MainMusic (ohThe);
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
				else if (numberOfDialogLines == 3) 
				{
					dialogueCoolDown = MusicianTrigger.StartText ("However, once Lord Angra Mainyu took over this peacful and happy place, he started taking things people cared about from them, like myself!");
					numberOfDialogLines = 4;
				}
				else if (numberOfDialogLines == 4) 
				{
					dialogueCoolDown = MusicianTrigger.StartText ("He stole my music pieces, and.... that fiend sent them to a publishing company");
					numberOfDialogLines = 5;
				}
				else if (numberOfDialogLines == 5) 
				{
					dialogueCoolDown = MusicianTrigger.StartText ("Only to reveal they were REJECTED!");
					numberOfDialogLines = 6;
				}
				else if (numberOfDialogLines == 6) 
				{
					dialogueCoolDown = MusicianTrigger.StartText ("Oh, the shame and saddness I felt is still with me.");
					numberOfDialogLines = 7;
				}
				else
				{
					MusicianTrigger.StartText ("");
					numberOfDialogLines = 0;
					isDialogOneDone = true;
					rachelIsMagic = true;
				}
			}
			else if (isDialogOneDone == true && rachelIsMagic == true) 
			{
				if (numberOfDialogLines == 0)
				{
					dialogueCoolDown = MusicianTrigger.StartText ("Now, child, if it ended at that, my pride would have survived, however it got WORSE.");
					numberOfDialogLines = 1;
				}
				else if (numberOfDialogLines == 1)
				{
					SoundManager.instance.MainMusic (ohTheDrama);
					dialogueCoolDown = MusicianTrigger.StartText ("Lord Angra Mainyu.. That Evil fiend");
					numberOfDialogLines = 2;
				}
				else if (numberOfDialogLines == 2)
				{
					dialogueCoolDown = MusicianTrigger.StartText ("After he knew I got rejected, he comes to me, and tries to COMMISSION me!");
					numberOfDialogLines = 3;
				}
				else if (numberOfDialogLines == 3)
				{
					dialogueCoolDown = MusicianTrigger.StartText ("If such an evil creature could request and claim to ENJOY my work");
					numberOfDialogLines = 4;
				}
				else if (numberOfDialogLines == 4)
				{
					dialogueCoolDown = MusicianTrigger.StartText ("Truly my work is less than worthless");
					numberOfDialogLines = 5;
				}
				else
				{
					MusicianTrigger.StartText ("");
					numberOfDialogLines = 0;
					isDialogTwoDone = true;
					rachelIsMagic = false;
				}
			}
			else if (isDialogOneDone == true && isDialogTwoDone == true)
			{
				if (numberOfDialogLines == 0)
				{
					SoundManager.instance.MainMusic (ofTheDramatic);
					dialogueCoolDown = MusicianTrigger.StartText ("Now, I have no inspiration! No motivation! I cannot produce a single satisfactory piece!");
					numberOfDialogLines = 1;
				}
				else if (numberOfDialogLines == 1)
				{
					dialogueCoolDown = MusicianTrigger.StartText ("The only comfort I've been given beyond pitying words was...");
					numberOfDialogLines = 2;
				}
				else if (numberOfDialogLines == 2)
				{
					dialogueCoolDown = MusicianTrigger.StartText ("... The Librarian offered to become my new muse.");
					numberOfDialogLines = 3;
				}
				else if (numberOfDialogLines == 3)
				{
					dialogueCoolDown = MusicianTrigger.StartText ("How does one write a song about a LIBRARIAN??");
					numberOfDialogLines = 4;
				}
				else
				{
					MusicianTrigger.StartText ("");
					numberOfDialogLines = 0;
					isDialogTwoDone = false;
					isDialogThreeDone = true;
				}
			}
			else if (isDialogOneDone == true && isDialogThreeDone == true)
			{
				if (numberOfDialogLines == 0)
				{
					SoundManager.instance.MainMusic (backtonorm);
					dialogueCoolDown = MusicianTrigger.StartText ("Oh, I got a bit carried away. Thank you, child, for hearing me out.");
					numberOfDialogLines = 1;
				}
				else if (numberOfDialogLines == 1)
				{
					dialogueCoolDown = MusicianTrigger.StartText ("... Child, as a new face, you give me an inkling of inspiration.");
					numberOfDialogLines = 2;
				}
				else if (numberOfDialogLines == 2)
				{
					dialogueCoolDown = MusicianTrigger.StartText ("You say you are going to fight Lord Angra Mainyu?");
					numberOfDialogLines = 3;
				}
				else if (numberOfDialogLines == 3)
				{
					dialogueCoolDown = MusicianTrigger.StartText ("If this is true, let me give you some more fitting atmosphere, maybe these old songs will be useful.");
					numberOfDialogLines = 4;
				}
				else if (numberOfDialogLines == 4)
				{
					dialogueCoolDown = MusicianTrigger.StartText ("You will find them in a box with a music note on it.");
					numberOfDialogLines = 5;
				}
				else if (numberOfDialogLines == 5)
				{
					dialogueCoolDown = MusicianTrigger.StartText ("I will write a victory song for you to lift up our spirits!");
					numberOfDialogLines = 6;
					musicPick = true;
				}
				else
				{
					MusicianTrigger.StartText ("");
					numberOfDialogLines = 0;
				}
			}
			else 
			{
				if (numberOfDialogLines == 0)
				{
					dialogueCoolDown = MusicianTrigger.StartText ("Thank you, child! Good luck!");
					numberOfDialogLines = 1;
				}
				else
				{
					MusicianTrigger.StartText ("");
					numberOfDialogLines = 0;
				}
			}
		}
	}
}
