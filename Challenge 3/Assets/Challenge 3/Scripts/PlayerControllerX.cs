using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{ 
    private Rigidbody playerRb;
    private AudioSource playerAudio;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;
    
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip groundSound;

    public float floatForce = 10;
    private float gravityModifier = 1.3f;
    public bool isLowEnough;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
        playerRb.AddForce(Vector3.up * 20, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        isLowEnough = transform.position.y < 4;

        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && isLowEnough)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.CompareTag("Bomb")) // if player collides with bomb, explode and set gameOver to true
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Money")) // if player collides with money, fireworks
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Ground") && !gameOver) // if player collides with ground, sound
        {
            playerAudio.PlayOneShot(groundSound, 1.0f);
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }
    }
}
