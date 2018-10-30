using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour {
	public static int CurrentAmmo;
	public int InternalAmmo;
	public GameObject AmmoDisplay;
	public static int LoadedAmmo;
	public int InternalLoadedAmmo;
	public GameObject LoadedAmmoDisplay;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		InternalAmmo = CurrentAmmo;
		InternalLoadedAmmo = LoadedAmmo;
		AmmoDisplay.GetComponent<Text>().text = InternalAmmo.ToString();
		LoadedAmmoDisplay.GetComponent<Text> ().text = InternalLoadedAmmo.ToString ();
	}
}
