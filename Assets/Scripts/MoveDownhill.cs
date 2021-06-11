using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownhill : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float zLimit;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(transform.position.z < zLimit)
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
