using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemManager {


	public static void GetItem( string ItemName ){
		Debug.Log (ItemName);
		PlayerPrefs.SetInt (ItemName, 1);
		PlayerPrefs.Save ();
	}

	public static bool HaveItem( string ItemName ){
		int ItemNum = PlayerPrefs.GetInt (ItemName, 0);
		if (ItemNum == 1) {
			return true;
		}{
			return false;
		}
	}

	public static void ClearItem(){
        Debug.Log("ClearItem");
        GlobalParameters.clear();
        PlayerPrefs.DeleteAll ();
	}


}
