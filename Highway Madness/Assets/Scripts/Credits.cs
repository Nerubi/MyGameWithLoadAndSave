using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public float transectionSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.up * transectionSpeed);

        if(transform.position.y > 1600f)
        {
            gameObject.SetActive(false);
        }
    }
}
