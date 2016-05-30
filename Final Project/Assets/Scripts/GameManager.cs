using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {

	private BoardManager boardScript;
	public GameObject healthPickUp;
	public GameObject musicPickUp;
	public static bool hPick = false;
	private Boss bossScript;

	private int level = 1;

	// Use this for initialization
	public void Start () {
		bossScript = GetComponent<Boss>();
		boardScript = GetComponent<BoardManager> ();
		InitGame ();
	}

	public void InitGame ()
	{
		boardScript.SetupScene(level);
	}

	// Update is called once per frame
	void Update () {
		if (bossScript.bossHealth < 1)
		{
			Application.LoadLevel (2);
		}
		if (hPick == true) {
			Instantiate (healthPickUp, new Vector3 (0, 2, 0f), Quaternion.identity);
			hPick = false;
		}
		if (MusicianDialog.musicPick == true) {
				Instantiate (musicPickUp, new Vector3 (5, 7, 0f), Quaternion.identity);
			MusicianDialog.musicPick = false;
		}
	}
}
