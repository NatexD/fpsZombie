using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {
	public AudioSource ReloadSound;
	public GameObject CrossObject;
	public GameObject MechanicsObject;
	public GameObject Flash;
	int ClipCount; 
	int ReserveCount;
	int ReloadAvailable;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && GlobalAmmo.LoadedAmmo > 0) {
			AudioSource gunsound = GetComponent<AudioSource>();
			gunsound.Play();
			GetComponent<Animation>().Play("gunshot");
			Flash.SetActive (true);
			StartCoroutine (FlashOff());
			GlobalAmmo.LoadedAmmo -= 1;
		}

		ClipCount = GlobalAmmo.LoadedAmmo;
		ReserveCount = GlobalAmmo.CurrentAmmo;

		if (ReserveCount == 0) {
			ReloadAvailable = 0;
		} else {
			ReloadAvailable = 30 - ClipCount;
		}

		if (GlobalAmmo.LoadedAmmo == 0) {
			if (ReloadAvailable > 0) {
				if (ReserveCount <= ReloadAvailable) {
					GlobalAmmo.LoadedAmmo += ReserveCount;
					GlobalAmmo.CurrentAmmo -= ReserveCount;
					ReloadAction ();
				} else {
					GlobalAmmo.LoadedAmmo += ReloadAvailable;
					GlobalAmmo.CurrentAmmo -= ReloadAvailable;
					ReloadAction ();
				}
			}
			StartCoroutine (EnableScripts ());
		}
	}

	IEnumerator EnableScripts(){
		yield return new WaitForSeconds(1.1f);
		this.GetComponent<GunFire> ().enabled = true;
		CrossObject.SetActive (true);
		MechanicsObject.SetActive (true);
	}

	void ReloadAction(){
		this.GetComponent<GunFire> ().enabled = false;
		CrossObject.SetActive (false);
		MechanicsObject.SetActive (false);
		ReloadSound.Play ();
		this.GetComponent<Animation> ().Play ("HandgunReload");
	}

	IEnumerator FlashOff(){
		yield return new WaitForSeconds (0.1f);
		Flash.SetActive (false);
	}
}
