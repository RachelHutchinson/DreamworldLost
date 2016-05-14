using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour {

	public GameObject handL;
	public GameObject handR;
	public GameObject handLG;
	public GameObject handRG;
	public GameObject hL;
	public GameObject hR;
	public GameObject handLP;
	public GameObject handRP;
	public int playerHealth;
	GameObject player;
	public GameObject boss;
	public static bool showTime = false;
	public static bool attackle = false;
	public static bool startAttack = false;
	public static bool purpleAttack = false;
	public static bool addedHealth = false;
	public static bool hit = false;
	public static bool hitP = false;
	public static bool purpleFace = false;
	Text playerHealthText;
	public int[] xCor = new int[21];
	public int[] yCor = new int[7];
	private Animator animator;

	public void Start () 
	{
		animator = GetComponent<Animator> ();
		showTime = false;
		playerHealth = 100;
		GameObject hL =
			Instantiate (handL, new Vector3 (1, 28, 0f), Quaternion.identity) as GameObject;
		GameObject hR =
			Instantiate (handR, new Vector3 (-11, 28, 0f), Quaternion.identity) as GameObject;
		playerHealthText = GameObject.Find ("Player Health").GetComponent<Text>();
	}

	public void Update () {
		if (showTime == true) {	
			playerHealthText.text = "氣: " + playerHealth;
		} else {
			playerHealthText.text = " ";
		}	


		if (attackle == true) {
			
			startAttack = true;
			StartCoroutine (AttackTime ());
			attackle = false;
		}
		if (hit == true){
			if (hitP == true) {
				playerHealth = playerHealth - 100;
				hit = false;
			} else {
				playerHealth = playerHealth - 40;
				hit = false;
			}
		}
		if (addedHealth == true) {
			playerHealth = playerHealth + 200;
			addedHealth = false;
		}
		if (playerHealth < 1) {
			playerHealth = 100;
			CountDown countDown = GameObject.Find("Timer").GetComponent<CountDown>();
			countDown.Restart ();
		}
		if (playerHealth < 80) {
			startAttack = false;
			purpleAttack = true;
			purpleFace = true;
			hitP = true;
			Destroy (hL);
			Destroy (hR);
			GameObject hLP =
				Instantiate (handLP, new Vector3 (1, 28, 0f), Quaternion.identity) as GameObject;
			GameObject hRP =
				Instantiate (handRP, new Vector3 (-11, 28, 0f), Quaternion.identity) as GameObject;
		} else {
			purpleAttack = false;
		}
			
	}

	public IEnumerator AttackTime ()
	{
		while (startAttack == true) {
			yield return new WaitForSeconds (1);
			GameObject hand =
				Instantiate (handL, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity) as GameObject;
			GameObject handT =
				Instantiate (handR, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity) as GameObject;
			GameObject handLe =
				Instantiate (handL, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity) as GameObject;
			GameObject handRi =
				Instantiate (handR, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity) as GameObject;
			GameObject hChaseL =
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
				Instantiate (handRG, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (1);
			Destroy (hand);
			Destroy (handT);
			Destroy (handLe);
			Destroy (handRi);
			Destroy (hChaseL);
			Destroy (hChaseR);
			Destroy (hChaseLO);
			Destroy (hChaseRO);
			Destroy (hChaseLT);
			Destroy (hChaseRT);

		}
		while (purpleAttack == true) {
			yield return new WaitForSeconds (1);
			GameObject hand =
				Instantiate (handLP, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity) as GameObject;
			GameObject handT =
				Instantiate (handRP, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity) as GameObject;
			GameObject handLe =
				Instantiate (handLP, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity) as GameObject;
			GameObject handRi =
				Instantiate (handRP, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity) as GameObject;
			GameObject hChaseL =
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
				Instantiate (handRG, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (1);
			Destroy (hand);
			Destroy (handT);
			Destroy (handLe);
			Destroy (handRi);
			Destroy (hChaseL);
			Destroy (hChaseR);
			Destroy (hChaseLO);
			Destroy (hChaseRO);
			Destroy (hChaseLT);
			Destroy (hChaseRT);
		}
	}

}
