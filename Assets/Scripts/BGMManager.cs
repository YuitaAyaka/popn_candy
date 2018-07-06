using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : Singleton<BGMManager> 
{ 
	public AudioClip bgmClip; 
	private AudioSource bgmSource; 

	protected override void Initialize() 
	{ 
		bgmSource = gameObject.AddComponent<AudioSource>(); 

		bgmSource.clip = bgmClip; 
		bgmSource.volume = 1.0f; 
		bgmSource.loop = true; 
		Play(); 
	} 

	// 再生。 
	public void Play() 
	{ 
		bgmSource.Play(); 
	} 

	// 停止。 
	public void Stop() 
	{ 
		bgmSource.Stop(); 
	} 

	// 一時停止。 
	public void Pause() 
	{ 
		bgmSource.Pause(); 
	} 

	// 音量設定。 
	public void SetVolume( float _volume ) 
	{ 
		bgmSource.volume = _volume; 
	} 
} 
