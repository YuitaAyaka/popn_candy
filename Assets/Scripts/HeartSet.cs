using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSet : MonoBehaviour {
	public GameObject[] hearts;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < hearts.Length; i++) {
			if (i < GlobalParameters.heart_num) {
				hearts [i].SetActive (true);
			}else{
				hearts [i].SetActive (false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
