using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int playerHealth = 3;
    public int coinsAmount = 0;

    private Rigidbody playerBody;
    private Animator playerAnim;
    [SerializeField] private float jumpForce = 3.0f;
    [SerializeField] private float characterMaxMovement;
    private bool isPlayerOnFloor = true;
    
   


    // Start is called before the first frame update
    void Start()
    {
        playerBody = gameObject.GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        CharacterMovement();
        if(playerHealth <= 0)
        {
            isPlayerOnFloor = false;
            playerAnim.SetBool("Die", true);
        }

    }

    void CharacterMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerOnFloor)
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isPlayerOnFloor = false;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            playerHealth--;
            if (playerHealth > 0) {
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Road"))
        {
            isPlayerOnFloor = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Health"))
        {
            playerHealth++;
        }
        if (other.gameObject.CompareTag("PowerUp"))
        {
            coinsAmount++;
        }
    }
}
