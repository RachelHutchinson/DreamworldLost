using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour {

	public GameObject handL;
	public GameObject handR;
	public GameObject handLG;
	public GameObject handRG;
	public GameObject handLB;
	public GameObject handRB;
	public GameObject hL;
	public GameObject hR;
	public GameObject handLP;
	public GameObject handRP;
	public GameObject bossFace;
	public int playerHealth;
	public int bossHealth;
	GameObject player;
	public GameObject boss;
	public static bool showTime = false;
	public static bool attackle = false;
	public static bool startAttack = false;
	public static bool faceAttack = false;
	public static bool purpleAttack = false;
	public static bool addedHealth = false;
	public static bool startDefence = false;
	public static bool hit = false;
	public static bool hitP = false;
	public static bool hitBoss = false;
	public static bool purpleFace = false;
	public static bool showDown = false;
	Text playerHealthText;
	Text bossHealthText;
	GameObject [] allTheHands;
	public int[] xCor = new int[21];
	public int[] yCor = new int[7];
	private Animator animator;

	public void Start () 
	{
		animator = GetComponent<Animator> ();
		showTime = false;
		playerHealth = 100;
		bossHealth = 1000;
		GameObject hL =
			Instantiate (handL, new Vector3 (1, 28, 0f), Quaternion.identity) as GameObject;
		GameObject hR =
			Instantiate (handR, new Vector3 (-11, 28, 0f), Quaternion.identity) as GameObject;
		playerHealthText = GameObject.Find ("Player Health").GetComponent<Text>();
		bossHealthText = GameObject.Find ("Boss Health").GetComponent<Text>();

	}

	public void Update () {
		allTheHands = GameObject.FindGameObjectsWithTag ("Hand");
		if (showTime == true) {	
			playerHealthText.text = "氣: " + playerHealth;
			bossHealthText.text = "氣: " + bossHealth;
		} else {
			playerHealthText.text = " ";
			bossHealthText.text = "";
		}	
		if (attackle == true) {
			faceAttack = true;
			showDown = true;
			StartCoroutine (AttackTime ());
			attackle = false;
		}
		if (hit == true){
			if (hitP == true) {
				playerHealth = playerHealth - 100;
				hit = false;
			} else {
				playerHealth = playerHealth - 20;
				hit = false;
			}
		}
		if (hitBoss == true) {
			bossHealth = bossHealth - 10;
			Debug.Log ("Damage to Boss");
			hitBoss = false;
		}
		if (addedHealth == true) {
			playerHealth = playerHealth + 200;
			addedHealth = false;
		}
		if (playerHealth < 1) {
			playerHealth = 100;
			bossHealth = 1000;
			StopCoroutine (AttackTime ());
			CountDown countDown = GameObject.Find("Timer").GetComponent<CountDown>();
			countDown.Restart ();
		}
		if (purpleAttack == true) {
			purpleAttack = true;
			purpleFace = true;
			hitP = true;
		} else {
			purpleAttack = false;
		}
			
	}

	public IEnumerator AttackTime ()
	{
		while (showDown == true)
			{
		if (faceAttack == true) {
			yield return new WaitForSeconds (1);
			for (int x = -1; x < -1 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			for (int x = -24; x < -24 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			yield return new WaitForSeconds (1);
			for (int x = -2; x < -2 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			for (int x = -23; x < -23 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			yield return new WaitForSeconds (1);
			for (int x = -3; x < -3 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			for (int x = -22; x < -22 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			yield return new WaitForSeconds (1);
			for (int x = -4; x < -4 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			for (int x = -21; x < -21 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			yield return new WaitForSeconds (1);
			for (int x = -5; x < -5 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			for (int x = -20; x < -20 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			yield return new WaitForSeconds (1);
			for (int x = -6; x < -6 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			for (int x = -19; x < -19 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			yield return new WaitForSeconds (1);
			for (int x = -7; x < -7 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			for (int x = -18; x < -18 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			yield return new WaitForSeconds (1);
			for (int x = -8; x < -8 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			for (int x = -17; x < -17 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			yield return new WaitForSeconds (1);
			for (int x = -9; x < -9 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			for (int x = -16; x < -16 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			yield return new WaitForSeconds (1);
			for (int x = -10; x < -10 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			for (int x = -15; x < -15 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			yield return new WaitForSeconds (1);
			for (int x = -11; x < -11 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity);
				}
			}
			for (int x = -14; x < -14 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity) as GameObject;
				}
			}
			yield return new WaitForSeconds (1);
			for (int i = 0; i < allTheHands.Length; i++) {
				Destroy (allTheHands [i]);
			}
			startAttack = true;
		}
		if (startAttack == true) {
			for (int x = -15; x < -2 + 1; x++) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity);
				}
			yield return new WaitForSeconds (1);
				Instantiate (handL, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity);
				Instantiate (handR, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity);
				Instantiate (handL, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity);
				Instantiate (handR, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity);
				yield return new WaitForSeconds (1);
				for (int i = 0; i < allTheHands.Length; i++) {
					Destroy (allTheHands [i]);
				}
				startAttack = false;
				startDefence = true;
			}
			}
		if (startDefence == true) {
				yield return new WaitForSeconds (1);
			for (int x = -1; x > -15 + 1; x--) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity);
				}
				yield return new WaitForSeconds (1);
				Instantiate (handLB, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity);
				Instantiate (handRB, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity);
				Instantiate (handLB, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity);
				Instantiate (handRB, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity);

				yield return new WaitForSeconds (1);
				for (int i = 0; i < allTheHands.Length; i++) {
					Destroy (allTheHands [i]);
				}
				purpleAttack = true;
				startDefence = false;
			}
		}
		if (purpleAttack == true) {
			for (int x = -15; x > -24 + 1; x--) {
				for (int y = 22; y < 27 + 1; y++) {
					GameObject toInstantiate = bossFace;
					Instantiate (toInstantiate, new Vector3 (x + 8, y, 0f), Quaternion.identity);
				}
				yield return new WaitForSeconds (1);
				Instantiate (handLP, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity);
				Instantiate (handRP, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity);
				Instantiate (handLP, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity);
				Instantiate (handRP, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity);
				/*GameObject hChaseL =
					Instantiate (handLG, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity) as GameObject;
				GameObject hChaseR =
					Instantiate (handRG, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity) as GameObject;
				GameObject hChaseLO =
					Instantiate (handLG, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity) as GameObject;
				GameObject hChaseRO =
					Instantiate (handRG, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity) as GameObject;
				GameObject hChaseLT =
					Instantiate (handLG, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity) as GameObject;
				GameObject hChaseRT =
					Instantiate (handRG, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity) as GameObject;*/
				yield return new WaitForSeconds (1);
				for (int i = 0; i < allTheHands.Length; i++) {
					Destroy (allTheHands [i]);
				}
				faceAttack = true;
				purpleAttack = false;
				}
			}
		}
	}
}
			
