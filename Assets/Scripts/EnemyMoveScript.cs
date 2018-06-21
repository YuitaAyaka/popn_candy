﻿/* EnemyMoveScript.cs */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour {

	GameObject player_green;

	private Rigidbody2D rb2d;
	Rigidbody2D rigidbody2D;
	public int speed = -3;
	public float waitTime = 1.0f ;
	bool waiting = false ;
	Vector3 initScale ;
	Vector3 revScale ;

	void Start () {
		// オブジェクトのRigidbody2Dを取得
		rb2d = GetComponent<Rigidbody2D> ();
		// PLAYERオブジェクトを取得
		player_green = GameObject.Find ("Player");

		initScale = transform.localScale;
		revScale = new Vector3 (initScale.x * -1.0f, initScale.y, initScale.z);
	}

	void Update () {
		// 移動関数の呼び出し
		if (waiting == false) {
			EnemyMove ();
		}
	}

	// ENEMYの移動関数1フレーム毎にUpdate関数から呼び出される
	void EnemyMove () {
		// PLAYERの位置を取得
		Vector2 targetPos = player_green.transform.position;
		// PLAYERのx座標
		float x = targetPos.x;
		// ENEMYは、地面を移動させるので座標は常に0とする
		float y = 0;
		// 移動を計算させるための２次元のベクトルを作る
		Vector2 direction = new Vector2 (
			x - transform.position.x, y).normalized;
		// ENEMYのRigidbody2Dに移動速度を指定する
		rb2d.velocity = direction * 6;
	

		if (direction.x < 0) {
			transform.localScale = initScale;
		} else {
			transform.localScale = revScale;
		}
	
	}    
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if ( collision.gameObject.tag == "Player")
		{
			StartCoroutine ("WaitForPlayer"); 
		}
	}

	private IEnumerator WaitForPlayer() {  
		// ログ出力  
		Debug.Log ("1");  
		waiting = true;
		// 1秒待つ  
		yield return new WaitForSeconds (waitTime);  

		waiting = false;

	}  

	}

