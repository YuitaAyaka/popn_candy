using UnityEngine;

public class AudioStop: MonoBehaviour{


	public AudioClip AudioStopName;
	public AudioClip AudioPlayName;
	// Use this for initialization
	private void Start()
	{
		PlayAudio("AudioPlayName");
	}

	// AudioSourceの再生＆停止
	private void PlayAudio(string AudioStopName)
	{
		// AudioSourceの取得
		AudioSource AudioSourceComponent = GameObject.Find(AudioStopName).GetComponent<AudioSource>();
		// 停止
		AudioSourceComponent.Stop();
	}
}