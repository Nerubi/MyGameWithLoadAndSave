using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerBody;
    [SerializeField] private float jumpForce = 3.0f;
    [SerializeField] private float characterMaxMovement;
   


    // Start is called before the first frame update
    void Start()
    {
        playerBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        CharacterMovement();

    }


    void CharacterMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        characterMaxMovement = transform.position.x;
        if (Input.GetKey(KeyCode.A) && characterMaxMovement > -0.25f)
        {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && characterMaxMovement < 0.9f)
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime);
        }
    }
}
