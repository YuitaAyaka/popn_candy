using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDispControl : MonoBehaviour {
	public GameObject[] itemImage ;
	public string[] itemNames;

	// Use this for initialization
	void Start () {
		
		for (int i = 0; i < itemImage.Length; i++) {

			Debug.Log (itemNames [i]);
			Debug.Log (ItemManager.HaveItem (itemNames [i]));
			if (ItemManager.HaveItem (itemNames [i])) {
				itemImage [i].SetActive (true);
			} else {
				itemImage [i].SetActive (false);
			}
		}
			}
		
	

	// Update is called once per frame
	void Update () {

	

	//public void Play(){
		
		//for (int i = 0; i < itemImage.Length; i++) {

			//Debug.Log (itemNames [i]);
		    //Debug.Log (ItemManager.HaveItem (itemNames [i]));
			//if (ItemManager.HaveItem (itemNames [i])) {
			//	itemImage [i].SetActive (true);
			//} else {
				//itemImage [i].SetActive (false);
			//	}
//}

		}
		}



