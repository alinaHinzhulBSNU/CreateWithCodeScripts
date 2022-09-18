using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30.0f;
    private float downBound = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound || transform.position.z < downBound)
        {
            Destroy(gameObject);
        }

        // Game over if an animal is not fed by pizza
        if (transform.position.z < downBound) Debug.Log("Game Over!");
    }
}
