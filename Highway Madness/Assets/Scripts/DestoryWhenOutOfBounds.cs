using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryWhenOutOfBounds : MonoBehaviour
{

    void Update()
    {
     if(gameObject.transform.position.z < -25)
        {
            Destroy(gameObject);
        }   
    }
}
