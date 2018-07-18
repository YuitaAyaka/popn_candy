using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySet : MonoBehaviour {

		public GameObject[] candys;

		// Use this for initialization
		void Start () {
		for (int i = 0; i < candys.Length; i++) {
			if (i < GlobalParameters.candy_num) {
				candys [i].SetActive (true);
				}else{
				candys [i].SetActive (false);
				}
			}
		}

		// Update is called once per frame
		void Update () {

		}
	}
