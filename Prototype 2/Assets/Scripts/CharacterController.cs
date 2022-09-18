using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 20.0f;

    public GameObject pizzaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        horizontalInput = Input.GetAxis("Horizontal");

        bool isInBounds = transform.position.x < xRange && transform.position.x > -xRange;
        bool canGoToLeft = horizontalInput < 0 && transform.position.x > -xRange;
        bool canGoToRight = horizontalInput > 0 && transform.position.x < xRange;

        if (isInBounds || canGoToLeft || canGoToRight)
        {    
            transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        }
        
        // Fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(pizzaPrefab, transform.position, transform.rotation);
        }
    }
}
