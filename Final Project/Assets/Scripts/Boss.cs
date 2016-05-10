using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour {

	public GameObject handL;
	public GameObject handR;
	public int playerHealth;
	public int damageOne;
	public static bool showTime = false;
	Text playerHealthText;
	//public static bool attack = false;
	//public int[] xCor = new int[16] {-10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5};
	//public int[] yCor = new int[5] {22, 23, 24, 25, 26};
	//public int xCord;
	//public int yCord;


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
			//attack = true;
			//AttackOnTitans ();
			StartCoroutine (AttackTime ());
			showTime = false;
		}
	}

	void OnTriggerStay2D (Collider2D other) 
	{
		if(other.tag == "Player"){
		playerHealth = playerHealth - damageOne;
			Debug.Log ("Hit!");
		}
	}

	//public void AttackOnTitans ()
	//{
		//while (attack == true) {
			//xRandom ();
			//yRandom ();
			//StartCoroutine (AttackTime ());
		//}
	//}

	public IEnumerator AttackTime ()
	{
			yield return new WaitForSeconds (2);
			GameObject hM =
				Instantiate (handL, new Vector3 (3, 25, 0f), Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (1);
			Destroy (hM);
			yield return new WaitForSeconds (2);
			GameObject hN =
				Instantiate (handR, new Vector3 (-5, 26, 0f), Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (1);
			Destroy (hN);
	}

	//public void xRandom ()
	//{
		//xCord = Random.Range(0, xCor.Length);
	//}

	//public void yRandom ()
	//{
		//yCord = Random.Range(0, yCor.Length);
	//}



}
