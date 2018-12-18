using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneMinute : MonoBehaviour
{

    public float timeLimit = 60.0f;
    public float sleepTime = 0.0f;
    private bool flagonetime = false;
    public string SceneName;


    public void Update()
    {
        if (!flagonetime)
        {
            sleepTime += Time.deltaTime;

            if (sleepTime > timeLimit) flagonetime = true;
        }

        if (flagonetime)
        {

            //transform.Rotate(Vector3.up * Time.deltaTime * 20, Space.World);
            SceneNavigator.Instance.Change(SceneName, 0.5f);

        }

        if (Input.GetMouseButton(0))
        {
            sleepTime = 0;
            flagonetime = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            sleepTime = 0;
            flagonetime = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sleepTime = 0;
            flagonetime = false;
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            sleepTime = 0;
            flagonetime = false;
        }


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            sleepTime = 0;
            flagonetime = false;
        }
    }
}


    //SceneNavigator.Instance.Change(scenename, 0.5f);