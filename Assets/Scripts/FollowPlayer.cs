using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0f, 15f, -70f);
 
    void Update()
    {
        
        transform.position = player.transform.position + offset;
    }
}
