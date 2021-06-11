using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    void Update()
    {
        if(transform.position.z > 250)
        {
            gameObject.SetActive(false);
        }
    }
}
