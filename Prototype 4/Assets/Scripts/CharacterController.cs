using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody charactersRigigdbody;
    private GameObject focalPoint;

    public GameObject powerupIndicator;

    public float speed = 3.0f;
    public float knockBackForce = 15.0f;
    public bool hasPowerup = false;

    // Start is called before the first frame update
    void Start()
    {
        charactersRigigdbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        charactersRigigdbody.AddForce(focalPoint.transform.forward * verticalInput * speed);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0); // nested object rotates with character
    }

    private void OnTriggerEnter(Collider other) // interaction, isTrigger checked
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine()); // other thread works 
        }
    }

    IEnumerator PowerupCountdownRoutine() // countdown
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision) // physical collision
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            GameObject enemy = collision.gameObject;
            Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();

            Vector3 knockBackDirection = enemy.transform.position - transform.position;
            enemyRigidbody.AddForce(knockBackDirection * knockBackForce, ForceMode.Impulse);
        }
    }
}