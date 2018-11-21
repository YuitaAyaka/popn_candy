using UnityEngine;
using System.Collections;

public class MoveBlock : MonoBehaviour
{

    private Vector3 initialPosition;

    void Start()
    {

        initialPosition = transform.position;

    }

    void Update()
    {

        transform.position = new Vector3(initialPosition.x, Mathf.Sin(Time.time) * 18.0f + initialPosition.y, initialPosition.z);

    }
}