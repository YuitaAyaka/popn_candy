using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTimer : MonoBehaviour {
	public float lifeTime = 0.5f ;

	// Use this for initialization
	void Start () {
		StartCoroutine ("destroyMyself");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator destroyMyself() {  
		// ログ出力  
		//Debug.Log ("1");  
	
		// 1秒待つ  
		yield return new WaitForSeconds (lifeTime);  

		// ログ出力  
		// Debug.Log ("3");
		Destroy(gameObject);
	}  

}
