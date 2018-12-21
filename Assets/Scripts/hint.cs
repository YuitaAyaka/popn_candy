using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint : MonoBehaviour
{

    public GameObject pannelObject;
    public GameObject[] hideObject;
    public float WaitlTime = 0.5f;
   


    void Start()
    {


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

            pannelObject.SetActive(true);


            for (int i = 0; i < hideObject.Length; i++)
            {
                hideObject[i].SetActive(false);
            }
      
    }

  

}







