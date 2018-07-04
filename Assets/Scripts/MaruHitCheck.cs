using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaruHitCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "enemy") {
			Destroy (collision.gameObject);
			// game over
		}
		if (collision.gameObject.tag == "break") {
			Destroy (collision.gameObject);
			// game over
		}
	}
}
