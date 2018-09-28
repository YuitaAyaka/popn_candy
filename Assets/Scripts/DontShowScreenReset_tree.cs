using UnityEngine;
using System.Collections;
public class DontShowScreenReset_tree : MonoBehaviour {
	//public float moveSpeed;
	public float speed = 10;
	public int spriteCount = 3;
	void Update () {
		
		// 左へ移動
	
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		// 右へ移動

		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
	}

	void OnBecameInvisible()
	{
		// スプライトの幅を取得
		float width = GetComponent<SpriteRenderer>().bounds.size.x;
		// 幅ｘ個数分だけ右へ移動
		transform.position += Vector3.right * width * spriteCount;
	}
}


