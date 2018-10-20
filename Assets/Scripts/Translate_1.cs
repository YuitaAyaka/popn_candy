using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate_1 : MonoBehaviour {

	public float xSpeed;

	void Start () {

	}

	// Update is called once per frame
	void Update ()
	{
		transform.Translate(new Vector3(xSpeed,0.0f,0.0f));		
	}

}
