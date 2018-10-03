using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour {
	public GameObject flowChartObj;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void startTalk(){
		flowChartObj.SetActive(true);
	}
	public void stopTalk(){
		gameObject.GetComponent<PolygonCollider2D> ().enabled = true;
		gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		gameObject.tag = "enemy";
	}
}