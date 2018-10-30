using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalHealth : MonoBehaviour {
	public static int PlayerHealth = 100;
	public int InternalHealth;
	public GameObject HealthDisplay;
	public GameObject HealthBar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		InternalHealth = PlayerHealth;
		HealthDisplay.GetComponent<Text> ().text = PlayerHealth.ToString();
		RectTransform bar = HealthBar.transform as RectTransform;
		bar.sizeDelta = new Vector2 (PlayerHealth, 10);
		if (PlayerHealth == 0) {
			SceneManager.LoadScene (1);
		}
	}
}
