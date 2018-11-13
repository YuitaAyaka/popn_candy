using UnityEngine;
using System.Collections;

public class ChangeColorScript : MonoBehaviour {

	//public GameObject myCube;

	// Use this for initialization
	void Start () 
	{	
		Color rand = new Color(Random.value, Random.value, Random.value, 1.0f);
		//renderer.material.color = rand;
	}


	// Update is called once per frame
	void Update () {

	}
}