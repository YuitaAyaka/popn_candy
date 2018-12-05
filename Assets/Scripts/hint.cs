using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint : MonoBehaviour
{

    public GameObject pannelObject;
    public GameObject[] hideObject;
   // public bool waittime = false;

    // Use this for initialization


    void Start()
   {
       // StartCoroutine("wait");

    }


    void Update()
    {

    }



    //IEnumerator wait()
  //  {
  //    yield return new WaitForSeconds(2);
   //   waittime = true;
 //  }




     public void PannelButtonPushed()
    {

      //  if (waittime == true)

        pannelObject.SetActive(true);


        for (int i = 0; i < hideObject.Length; i++)
            {
                hideObject[i].SetActive(false);
            }
      // waittime = false;

    }

    
}









