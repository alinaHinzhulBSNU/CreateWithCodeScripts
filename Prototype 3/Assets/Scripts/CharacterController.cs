using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Animator animator;
    private AudioSource audioSource;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    public float jumpForce = 700.0f;
    public float gravityModifier = 1.5f;

    public bool isOnGround = true;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // JUMP
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            // Character is not on the ground anymore
            isOnGround = false;

            // Move up
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
            // Stop using dirt FX
            dirtParticle.Stop();

            // Show special animation
            animator.SetTrigger("Jump_trig");

            // Play sound of jump
            audioSource.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Collision with the ground
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle")) // Collision with an obstacle
        {
            // Game over if character hit an obstacle
            isGameOver = true;

            // Character dies
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);

            // Stop dirt particle
            dirtParticle.Stop();

            // Show explosion
            explosionParticle.Play();

            // Play sound of crash
            audioSource.PlayOneShot(crashSound, 1.0f);
        }
    }
}
