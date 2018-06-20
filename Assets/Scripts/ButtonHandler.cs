using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour {
	void Start () {
	}

	void Update () {
	}

	public void OnClick() { // 必ず public にする
		//Debug.Log ("clicked");
		GetComponent<Animator>().SetInteger("Direction", 0);
		gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
	}
}
