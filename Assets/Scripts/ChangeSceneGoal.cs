using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneGoal : MonoBehaviour {
	public string SceneName1;
	public string SceneName2;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void change(){
		if (GlobalParameters.courseSelect) {
			SceneManager.LoadScene (SceneName1);
		} else {
			SceneManager.LoadScene (SceneName2);
		}
	}
}
