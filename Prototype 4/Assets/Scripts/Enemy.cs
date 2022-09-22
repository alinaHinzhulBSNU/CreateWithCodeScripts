using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRigidbody;
    private GameObject character;

    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        character = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (character.transform.position - transform.position).normalized;
        enemyRigidbody.AddForce(lookDirection * speed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
