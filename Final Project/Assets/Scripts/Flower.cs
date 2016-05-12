using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour {
	
		GameObject flower;
		public static bool flowerBool = false;

		void Start () {
			flower = GameObject.FindGameObjectWithTag ("Flower");
		}

		void OnTriggerStay2D (Collider2D other) {
			if (DialogTrigger.nurseDialogue == true) {

				if (Input.GetKeyDown (KeyCode.Space)) 
				{
					flowerBool = true;
					Destroy (flower);
					return;
				}
			}
			}
		}
