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
	public bool checkIfDead = false;
	Text playerHealthText;
	Text bossHealthText;
	GameObject [] allTheHands;
	public int[] xCor = new int[21];
	public int[] yCor = new int[7];
	private Animator animator;
	IEnumerator bossCoroutine;

	public void Start () 
	{
		animator = GetComponent<Animator> ();
		showTime = false;
		playerHealth = 100;
		bossHealth = 10;
		GameObject hL =
			Instantiate (handL, new Vector3 (1, 28, 0f), Quaternion.identity) as GameObject;
		GameObject hR =
			Instantiate (handR, new Vector3 (-11, 28, 0f), Quaternion.identity) as GameObject;
		playerHealthText = GameObject.Find ("Player Health").GetComponent<Text>();
		bossHealthText = GameObject.Find ("Boss Health").GetComponent<Text>();
		bossCoroutine = AttackTime ();

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
			checkIfDead = false;
			faceAttack = true;
			showDown = true;
			StartCoroutine (bossCoroutine);
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
			StopCoroutine (bossCoroutine);
			bossCoroutine = AttackTime ();
			for (int i = 0; i < allTheHands.Length; i++) {
				Destroy (allTheHands [i]);
			}
			showDown = false;
			showTime = false;
			attackle = false;
			startAttack = false;
			faceAttack = false;
			purpleAttack = false;
			addedHealth = false;
			startDefence = false;
			CountDown countDown = GameObject.Find("Timer").GetComponent<CountDown>();
			countDown.Restart ();
			playerHealth = 100;
			bossHealth = 10;
		}
			
	}
		

	public IEnumerator AttackTime ()
	{
			while (showDown == true) {
				if (faceAttack == true) {
					yield return new WaitForSeconds (1);
					for (int x = 0; x < 10; x++) {
						for (int y = 22; y < 27 + 1; y++) {
							GameObject toInstantiate = bossFace;
							Instantiate (toInstantiate, new Vector3 (7 - x, y, 0f), Quaternion.identity);
							Instantiate (toInstantiate, new Vector3 (x - 16, y, 0f), Quaternion.identity);
						}
						yield return new WaitForSeconds (1);
						
					}
					for (int i = 0; i < allTheHands.Length; i++) {
						Destroy (allTheHands [i]);
					}
					faceAttack = false;
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
					hitP = true;
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
						yield return new WaitForSeconds (1);
						for (int i = 0; i < allTheHands.Length; i++) {
							Destroy (allTheHands [i]);
						}
						faceAttack = true;
						hitP = false;
						purpleAttack = false;
					}
				}
			}
		//}
	}
}
			
