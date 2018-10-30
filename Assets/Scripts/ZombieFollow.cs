using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollow : MonoBehaviour {
	public GameObject ThePlayer;
	public float TargetDistance;
	public float AllowRange = 10;
	public GameObject TheEnemy;
	public float EnemySpeed;
	public int AttackTrigger;
	public RaycastHit Shot;

	public int isAttacking;
	public GameObject PainScreen;
	public AudioSource Hurt01;
	public AudioSource Hurt02;
	public AudioSource Hurt03;
	public int PainSound;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		transform.LookAt (ThePlayer.transform);
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot)) {
			TargetDistance = Shot.distance;
			if (TargetDistance <= AllowRange) {
				EnemySpeed = 0.02f;
				if (AttackTrigger == 0) {
					TheEnemy.GetComponent<Animation> ().Play ("Walking");
					transform.position = Vector3.MoveTowards (transform.position, ThePlayer.transform.position, EnemySpeed);
				}
			} else {
				EnemySpeed = 0;
				TheEnemy.GetComponent<Animation> ().Play ("Idle");
			}
		}

		if (AttackTrigger == 1) {
			EnemySpeed = 0;
			TheEnemy.GetComponent<Animation> ().Play ("Attacking");
		}
	}

	void OnTriggerEnter(){
		AttackTrigger = 1;
	}

	void OnTriggerExit(){
		AttackTrigger = 0;
	}

	IEnumerator EnemyDamage(){
		isAttacking = 1;
		PainSound = Random.Range (1, 4);
		yield return new WaitForSeconds (0.9f);
		PainScreen.SetActive (true);
		GlobalHealth.PlayerHealth -= 20;
		if (PainSound == 1) {
			Hurt01.Play ();
		} else if (PainSound == 2) {
			Hurt02.Play ();
		} else {
			Hurt03.Play ();
		}
		yield return new WaitForSeconds (0.05f);
		PainScreen.SetActive (false);
		yield return new WaitForSeconds (1);
		isAttacking = 0;
	}
}
