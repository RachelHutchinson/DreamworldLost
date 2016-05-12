using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour {

	public GameObject handL;
	public GameObject handR;
	public int playerHealth;
	GameObject player;
	public static bool showTime = false;
	public static bool attackle = false;
	public static bool startAttack = false;
	public static bool addedHealth = false;
	public static bool hit = false;
	Text playerHealthText;
	public int[] xCor = new int[21];
	public int[] yCor = new int[7];


	public void Start () 
	{
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
			playerHealth = playerHealth - 20;
			Debug.Log (playerHealth);
			hit = false;
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
	}

	public IEnumerator AttackTime ()
	{
		while (startAttack == true) {
			yield return new WaitForSeconds (3);
			GameObject testHand =
			Instantiate (handL, new Vector3 (0, 25, 0f), Quaternion.identity) as GameObject;
			GameObject hand =
			Instantiate (handL, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (1);
			Destroy (hand);
			yield return new WaitForSeconds (3);
			GameObject handT =
			Instantiate (handR, new Vector3 (Random.Range (-15, xCor.Length - 15), Random.Range (23, yCor.Length + 23), 0f), Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (1);
			Destroy (handT);
		}
		
	}

}
