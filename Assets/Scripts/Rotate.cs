﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  Rotate: MonoBehaviour {

	public float RotateVector ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(new Vector3(0.0f,0.0f,RotateVector));		
	}

}
