using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaruHitCheck : MonoBehaviour {
	public GameObject effectObj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "enemy") {
			if (effectObj != null) {
				GameObject.Instantiate (effectObj, collision.gameObject.transform.position, Quaternion.identity);
			}

			Destroy (collision.gameObject);
			// game over

			// エフェクトを表示

		}
		if (collision.gameObject.tag == "break") {
			Destroy (collision.gameObject);
			// game over
		}
	}


	// Instanciate 
	// Prefabでアニメーション再生を作っておく
	// Play on Start
	// エフェクトのオブジェクトに、時間が経ったら自分が消えるスクリプトを追加

}
