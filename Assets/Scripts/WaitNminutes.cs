﻿using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.SceneManagement;



public class WaitNminutes : MonoBehaviour {



	float TimeCount　= 2;

	public string scenename;

	// Use this for initialization
	void Start () {

	}

	void Update () {

		TimeCount -= Time.deltaTime;
		if(TimeCount <= 0)
		{
			
			{
				SceneNavigator.Instance.Change(scenename, 0.5f);
			}

			//ここに処理
			//TimeCount = 15;
		}

	}


}
