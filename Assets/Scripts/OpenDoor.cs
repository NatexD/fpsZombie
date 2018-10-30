using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour {
	public GameObject TextDisplay;
	float TheDistance = PlayerCasting.DistanceFromTarget;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TheDistance = PlayerCasting.DistanceFromTarget;
	}

	void OnMouseOver(){
		if (TheDistance <= 2) {
			TextDisplay.GetComponent<Text> ().text = "[E] Interact";
			if(Input.GetButtonDown("Interact")){
				StartCoroutine(DoorInteraction());
			}
		}
	}

	void OnMouseExit(){
		TextDisplay.GetComponent<Text> ().text = "";
	}

	IEnumerator DoorInteraction(){
		this.GetComponent<Animator>().enabled = true;
		yield return new WaitForSeconds (1f);
		this.GetComponent<Animator>().enabled = false;
	}
}
