using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRigidbody;
    private GameManager gameManager;

    float minSpeed = 12;
    float maxSpeed = 16;

    float maxTorque = 10;
    
    float xRange = 4;
    float y = -2;

    public int pointValue;
    public ParticleSystem particleEffect;

    // Start is called before the first frame update
    void Start()
    {
        targetRigidbody = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRigidbody.AddForce(RandomForce(),ForceMode.Impulse);
        targetRigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(particleEffect, transform.position, particleEffect.transform.rotation); // effect
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), y);
    }
}
