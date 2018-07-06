using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBGM : MonoBehaviour {
	// Use this for initialization

	void Start () {
		BGMManager.Instance.Stop ();
	}

	// Update is called once per frame
	void Update () {

	}
}
