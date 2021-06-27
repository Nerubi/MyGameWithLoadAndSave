using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int playerHealth = 3;
    public int coinsAmount = 0;
    public AudioClip jumpSound;
    public AudioClip powerUpSound;
    public AudioClip playerHitSound;
    public ParticleSystem playerHit;
    private AudioSource playerAudio;

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
        playerAudio = GetComponent<AudioSource>();
        MainManager.Instance.coinsCollected = 0;
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
            playerAudio.PlayOneShot(jumpSound);
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
            Instantiate(playerHit, gameObject.transform.position, gameObject.transform.rotation);
            playerAudio.PlayOneShot(playerHitSound);
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
            playerAudio.PlayOneShot(powerUpSound);
            playerHealth++;
        }
        if (other.gameObject.CompareTag("PowerUp"))
        {
            MainManager.Instance.coinsCollected = MainManager.Instance.coinsCollected + 1;
            playerAudio.PlayOneShot(powerUpSound);
            coinsAmount++;
        }
    }
}
