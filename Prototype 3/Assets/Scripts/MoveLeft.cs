using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10.0f;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GameObject.Find("Character").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!characterController.isGameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < -10 && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
