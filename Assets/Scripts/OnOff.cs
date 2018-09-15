using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour {


	public GameObject targetObject;
	public GameObject toNextObject;

	public bool b;




	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void buttonPushed(){
		if (PlayerPrefs.GetInt ("Stage1Clear", -1) == 1) {
			// クリアした時の表示
			toNextObject.SetActive(true);
		} else {
			targetObject.SetActive (b);
		}

	}




}
