﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour {


		void Start () {

		}

		// Update is called once per frame
		void Update ()
		{
		transform.Translate(new Vector3(0.0f,0.1f,0.0f));		
		}

	}
