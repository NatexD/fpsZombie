using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossAnimate : MonoBehaviour {
	public GameObject UpCurls;
	public GameObject DownCurls;
	public GameObject LeftCurls;
	public GameObject RightCurls;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && GlobalAmmo.LoadedAmmo > 0) {
			UpCurls.GetComponent<Animator>().enabled = true;
			DownCurls.GetComponent<Animator>().enabled = true;
			LeftCurls.GetComponent<Animator>().enabled = true;
			RightCurls.GetComponent<Animator>().enabled = true;
			StartCoroutine(WaitingAni());
		}
	}

	IEnumerator WaitingAni(){
		yield return new WaitForSeconds (0.1f);
		UpCurls.GetComponent<Animator>().enabled = false;
		DownCurls.GetComponent<Animator>().enabled = false;
		LeftCurls.GetComponent<Animator>().enabled = false;
		RightCurls.GetComponent<Animator>().enabled = false;
	}
}
