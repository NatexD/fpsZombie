using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour {
	public static float DistanceFromTarget;
	float ToTarget;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit Hit;
		Ray HitRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
		if (Physics.Raycast(HitRay, out Hit)) {
			ToTarget = Hit.distance;
			DistanceFromTarget = ToTarget;
		}
	}
}
