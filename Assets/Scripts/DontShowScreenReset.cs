using UnityEngine;
using System.Collections;
public class DontShowScreenReset : MonoBehaviour {
	public float speed = 10;
	public int spriteCount = 3;
	void Update () {
		// 左へ移動
		transform.position += Vector3.left * speed * Time.deltaTime;
	}
	void OnBecameInvisible()
	{
		// スプライトの幅を取得
		float width = GetComponent<SpriteRenderer>().bounds.size.x;
		// 幅ｘ個数分だけ右へ移動
		transform.position += Vector3.right * width * spriteCount;
	}
}