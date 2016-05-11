using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour {

	public GameObject handL;
	public GameObject handR;
	public int playerHealth;
	public int damageOne;
	GameObject player;
	public static bool showTime = false;
	public static bool attackle = false;
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
		if (showTime == true) 
		{	
			playerHealthText.text = "氣: " + playerHealth; 
		}
		if (attackle == true) {
			StartCoroutine (AttackTime ());
			attackle = false;
		}
		if (hit == true){	
			playerHealth = playerHealth - damageOne;
			hit = false;
		}
	}

	public IEnumerator AttackTime ()
	{
			yield return new WaitForSeconds (3);
			GameObject testHand =
			Instantiate (handL, new Vector3 (0, 25, 0f), Quaternion.identity) as GameObject;
			GameObject hand =
			Instantiate (handL, new Vector3 (Random.Range(-15, xCor.Length-15), Random.Range(23, yCor.Length+23), 0f), Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (1);
			Destroy (hand);
			yield return new WaitForSeconds (3);
			GameObject handT =
			Instantiate (handR, new Vector3 (Random.Range(-15, xCor.Length-15), Random.Range(23, yCor.Length+23), 0f), Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (1);
			Destroy (handT);
		yield return new WaitForSeconds (3);
		GameObject handU =
			Instantiate (handL, new Vector3 (Random.Range(-15, xCor.Length-15), Random.Range(23, yCor.Length+23), 0f), Quaternion.identity) as GameObject;
		yield return new WaitForSeconds (1);
		Destroy (handU);
		yield return new WaitForSeconds (3);
		GameObject handV =
			Instantiate (handR, new Vector3 (Random.Range (-15, xCor.Length-15), Random.Range(23, yCor.Length+23), 0f), Quaternion.identity) as GameObject;
		yield return new WaitForSeconds (1);
		Destroy (handV);
		yield return new WaitForSeconds (3);
		GameObject handW =
			Instantiate (handL, new Vector3 (Random.Range(-15, xCor.Length-15), Random.Range(23, yCor.Length+23), 0f), Quaternion.identity) as GameObject;
		yield return new WaitForSeconds (1);
		Destroy (handW);
		yield return new WaitForSeconds (3);
		GameObject handX =
			Instantiate (handR, new Vector3 (Random.Range(-15, xCor.Length-15), Random.Range(23, yCor.Length+23), 0f), Quaternion.identity) as GameObject;
		yield return new WaitForSeconds (1);
		Destroy (handX);
	}

}
