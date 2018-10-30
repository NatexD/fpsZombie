using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour {
	public AudioSource AmmoSound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collision){
		AmmoSound.Play ();
		if (GlobalAmmo.LoadedAmmo == 0) {
			GlobalAmmo.LoadedAmmo += 30;
			this.gameObject.SetActive (false);
		} else {
			if (GlobalAmmo.CurrentAmmo < 90) {
				GlobalAmmo.CurrentAmmo += 30;
				this.gameObject.SetActive(false);
			}
		}
	}
}
