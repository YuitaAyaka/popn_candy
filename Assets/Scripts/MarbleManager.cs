using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MarbleManager : MonoBehaviour {


    public GameObject MarbleScore;
    public GameObject MarbleScore1;
    public int MarbleNumber;
   

    private void Start()
    {
        MarbleScore.GetComponent<Text>().text = MarbleNumber.ToString();
        MarbleScore1.GetComponent<Text>().text = MarbleNumber.ToString();

        PlayerPrefs.Save();

    }

   


        public static void clearMarble()
    {
        PlayerPrefs.DeleteAll();
    }


}
