using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PositionManager {
	static Dictionary<string,Vector3> scenePosDic ;


	public static void setPos(string sceneName, Vector3 pos){
		if ( scenePosDic == null ){
			scenePosDic = new Dictionary<string, Vector3>();
		}
		scenePosDic[sceneName] = pos ;
	}

	public static Vector3 getPos(string sceneName){
		if ( scenePosDic == null ){
			scenePosDic = new Dictionary<string, Vector3>();
		}
		return scenePosDic[sceneName] ;
	}

	public static bool hasPos( string sceneName ){
		if ( scenePosDic == null ){
			scenePosDic = new Dictionary<string, Vector3>();
		}
		return scenePosDic.ContainsKey( sceneName );
	}

}
