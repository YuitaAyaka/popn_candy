using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.SceneManagement;



public class WaitAudio : MonoBehaviour {

	public AudioClip audioClip1;
	private AudioSource audioSource;
	float TimeCount　= 1.0f;



	// Use this for initialization
	void Start () {

	}

	void Update () {

		TimeCount -= Time.deltaTime;
		if(TimeCount <= 0)
		{
			
			audioSource = gameObject.GetComponent<AudioSource>();
			audioSource.clip = audioClip1;
			audioSource.Play ();


			//ここに処理
			//TimeCount = 15;
		}

	}


}
