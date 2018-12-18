using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MarbleManager : MonoBehaviour {


    public GameObject MarbleScore;
    public GameObject MarbleScore1;
    public int MarbleNumber;
    public GameObject[] marbles;

    private void Start()
    {
        MarbleScore.GetComponent<Text>().text = MarbleNumber.ToString();
        MarbleScore1.GetComponent<Text>().text = MarbleNumber.ToString();


        for (int i = 0; i < marbles.Length; i++)
        {
            if (i < GlobalParameters.marble_num)
            {
                marbles[i].SetActive(true);
            }
            else
            {
                marbles[i].SetActive(false);
            }
        }


        PlayerPrefs.Save();

    }

   


        public static void clearMarble()
    {
        PlayerPrefs.DeleteAll();
    }


}
