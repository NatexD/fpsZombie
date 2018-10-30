using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
	public GameObject ThePlayer;
	public GameObject TheEnemy;
	float EnemySpeed;
	int MoveTrigger = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveTrigger = 0;
		if (MoveTrigger == 1) {
			EnemySpeed = 0.02f;
			transform.position = Vector3.MoveTowards (transform.position, ThePlayer.transform.position, EnemySpeed);
		}
	}
}
