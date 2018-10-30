using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandGunPickup : MonoBehaviour {
	float distance = PlayerCasting.DistanceFromTarget;
	public GameObject TextDisplay;
	public GameObject FakeGun;
	public GameObject RealGun;
	public GameObject LabelPanel;
	public AudioSource HandGunPickupSound;
	public GameObject UpCurls;
	public GameObject DownCurls;
	public GameObject LeftCurls;
	public GameObject RightCurls;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		distance = PlayerCasting.DistanceFromTarget;
	}

	void PickupHandGun(){
		FakeGun.SetActive (false);
		RealGun.SetActive (true);
		LabelPanel.SetActive (true);
		UpCurls.SetActive (true);
		DownCurls.SetActive (true);
		LeftCurls.SetActive (true);
		RightCurls.SetActive (true);
	}

	void OnMouseOver(){
		if (distance <= 2) {
			TextDisplay.GetComponent<Text> ().text = "[E] Pickup";
			if(Input.GetButtonDown("Interact")){
				HandGunPickupSound.Play ();
				PickupHandGun ();
			}
		}
	}

	void OnMouseExit(){
			TextDisplay.GetComponent<Text> ().text = "";
	}
}
