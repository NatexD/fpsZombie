using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunDamage : MonoBehaviour {
	int damageAmount = 5;
	float targetDistance;
	float allowRange = 15;
	RaycastHit Shot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray shootRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
		if(Input.GetButtonDown("Fire1")){
			if (Physics.Raycast(shootRay, out Shot)) {
				targetDistance = Shot.distance;
				if (targetDistance < allowRange) {
					Shot.transform.SendMessage ("DeductPoints", damageAmount, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
