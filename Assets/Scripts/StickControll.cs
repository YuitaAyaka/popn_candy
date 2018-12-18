using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickControll : MonoBehaviour
{
	public GameObject stickCenter;
	public GameObject[] Arrows;
	public GameObject center;
	public GameObject player ;
	Vector3 stickCenterPos;
	float angleStep;

	// Use this for initialization
	void Start()
	{
		//Debug.Log(Screen.width);
		//Debug.Log(Screen.height);

		float xMin = ((float)Screen.width / 2.0f) * -1.0f;
		float yMin = ((float)Screen.height / 2.0f) * -1.0f;
		stickCenterPos.x = stickCenter.GetComponent<RectTransform>().anchoredPosition.x - xMin;
		stickCenterPos.y = stickCenter.GetComponent<RectTransform>().anchoredPosition.y - yMin;
		stickCenterPos.z = 0.0f;

		// Debug.Log(stickCenterPos);

		angleStep = 360.0f / (float)Arrows.Length;

		// Debug.Log(angleStep);


	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Vector3 mousePos = Input.mousePosition;
			// Debug.Log(mousePos);

			Vector3 dir = mousePos - stickCenterPos;
			if (dir.magnitude / Screen.width < 0.2f) {
				center.SetActive(false);

				dir.Normalize ();
				// Debug.Log(dir);

				float angle = Vector3.Angle (Vector3.up, dir);
				// Debug.Log(angle);
				if (dir.x < 0) {
					angle = 360.0f - angle;
				}
				// Debug.Log(angle);

				int dispIndex = -1;
				if (angle < angleStep * 0.5f || angle > 360.0f - angleStep * 0.5f) {
					dispIndex = 0;
				} else {
					dispIndex = (int)((angle - angleStep * 0.5f) / angleStep) + 1;
				}
				for (int i = 0; i < Arrows.Length; i++) {
					if (i == dispIndex) {
						Arrows [i].SetActive (true);
					} else {
						Arrows [i].SetActive (false);
					}
				}

				if (dispIndex == 0) {
					player.GetComponent<Player> ().UpPushed ();
				}
				if (dispIndex == 1) {
					player.GetComponent<Player> ().UpPushed();
				}
				if (dispIndex == 2) {
					player.GetComponent<Player> ().RightPushed ();
				}
				if (dispIndex == 3) {
					player.GetComponent<Player> ().RightPushed ();
				}
				if (dispIndex == 5) {
					player.GetComponent<Player> ().LeftPushed ();
				}
				if (dispIndex == 6) {
					player.GetComponent<Player> ().LeftPushed ();
				}
				if (dispIndex == 7) {
					player.GetComponent<Player> ().UpPushed();
				}
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			for (int i = 0; i < Arrows.Length; i++)
			{
				Arrows[i].SetActive(false);
			}
			center.SetActive(true);
			player.GetComponent<Player> ().Released ();
		}
		if (Input.GetMouseButtonDown(0))
		{
			// center.SetActive(false);
		}
	}
}