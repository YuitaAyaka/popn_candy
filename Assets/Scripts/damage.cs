using UnityEngine;
using System.Collections;

public class damage : MonoBehaviour {


	public bool on_damage = false;       //ダメージフラグ
	private SpriteRenderer renderer;

	// Use this for initialization
	void Start () 
	{
		//点滅処理の為に呼び出しておく
		renderer = gameObject.GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () 
	{
		// ダメージフラグがtrueで有れば点滅させる
		if(on_damage){
			float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
			renderer.color = new Color(1f,1f,1f,level);
		}
	}

	// 敵とぶつかった際の処理
	void OnCollisionEnter2D(Collision2D col){

		//  敵とぶつかったかつダメージフラグがfalse
		if(!on_damage && col.gameObject.tag == "mob"){
			
			OnDamageEffect();
		}
	}

	//　ダメージを受けた際の動き
	void OnDamageEffect()
	{
		// ダメージフラグON
		on_damage = true;

		// プレイヤーの位置を後ろに飛ばす
		float s = 100f * Time.deltaTime;
		transform.Translate(Vector3.up * s);

		// プレイヤーのlocalScaleでどちらを向いているのかを判定
		if(transform.localScale.x >= 0){
			transform.Translate(Vector3.left * s);
		}else{
			transform.Translate(Vector3.right * s);
		}

		// コルーチン開始
		StartCoroutine("WaitForIt");
	}

	IEnumerator WaitForIt()
	{
		// 1秒間処理を止める
		yield return new WaitForSeconds(1);

		// １秒後ダメージフラグをfalseにして点滅を戻す
		on_damage = false;
		renderer.color = new Color(1f,1f,1f,1f);
	}
}