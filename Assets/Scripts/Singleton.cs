using UnityEngine; 
using System.Collections; 

//------------------------------------------------------------------------------ 
// シングルトン 
//------------------------------------------------------------------------------ 
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T> 
{ 
	//------------------------------------------------------------------ 
	// member 
	//------------------------------------------------------------------ 
	private static T m_Instance = null; 

	//------------------------------------------------------------------ 
	// インスタンス取得 
	//------------------------------------------------------------------ 
	public static T Instance 
	{ 
		get 
		{ 
			if( m_Instance == null ) 
			{ 
				m_Instance = (T)FindObjectOfType(typeof(T) ); 
				if( m_Instance == null ) 
				{ 
					Debug.LogError( typeof(T) + "is nothing" ); 
				} 
			} 
			return m_Instance; 
		} 
	} 

	//------------------------------------------------------------------ 
	// 初期化 
	//------------------------------------------------------------------ 
	protected abstract void Initialize(); 

	//------------------------------------------------------------------ 
	// Awake 
	//------------------------------------------------------------------ 
	private void Awake() 
	{ 
		if( m_Instance != null && m_Instance != (T)this ) 
		{ 
			Destroy(gameObject); 
			return; 
		} 

		Initialize(); 

		DontDestroyOnLoad( gameObject ); 

		m_Instance = (T)this; 
	} 
} 