using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{

    public float speedOfObjectTowardsPlayer = 5;
    private PlayerControl PlayerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speedOfObjectTowardsPlayer * Time.deltaTime,Space.World);
        if(PlayerControllerScript.playerHealth <= 0)
        {
            speedOfObjectTowardsPlayer = 0;
        }
    }
}
