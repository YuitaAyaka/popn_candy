﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadescenebutton : MonoBehaviour {
	public string scenename;
	public bool clearPlayerPref = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	public void changeScene()
	{
		if (clearPlayerPref) {
			
		}
		SceneNavigator.Instance.Change(scenename, 0.5f);
	}
}
