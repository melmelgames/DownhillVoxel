using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpZed : MonoBehaviour
{
    private float speed;
    private float zLimit;
    private Vector3 startPos;

    void Start()
    {
        speed = SpawnManager.instance.GetSpeed();
        zLimit = SpawnManager.instance.GetZboundary();
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(transform.position.z > zLimit)
        {
            ResetPosition();
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

    void ResetPosition()
    {
        transform.position = startPos;
    }


}
