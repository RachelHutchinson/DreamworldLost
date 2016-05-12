using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {

	private BoardManager boardScript;
	public GameObject healthPickUp;
	public static bool hPick = false;

	private int level = 1;

	// Use this for initialization
	public void Start () {
		boardScript = GetComponent<BoardManager> ();
		InitGame ();
	}

	public void InitGame ()
	{
		boardScript.SetupScene(level);
	}

	// Update is called once per frame
	void Update () {
		if (hPick == true) {
			GameObject health=
				Instantiate (healthPickUp, new Vector3 (0, 3, 0f), Quaternion.identity) as GameObject;
			hPick = false;
		}
	}
}
