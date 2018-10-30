using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunReloading : MonoBehaviour {
	public AudioSource ReloadSound;
	public GameObject CrossObject;
	public GameObject MechanicsObject;
	int ClipCount; 
	int ReserveCount;
	int ReloadAvailable;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ClipCount = GlobalAmmo.LoadedAmmo;
		ReserveCount = GlobalAmmo.CurrentAmmo;

		if (ReserveCount == 0) {
			ReloadAvailable = 0;
		} else {
			ReloadAvailable = 30 - ClipCount;
		}

		if (Input.GetButtonDown ("Reload") && ReserveCount > 0 && ClipCount < 30) {
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
}
