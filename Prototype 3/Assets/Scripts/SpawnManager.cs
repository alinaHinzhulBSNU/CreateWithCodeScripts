using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private float delay = 2.0f;
    private float interval = 3.0f;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GameObject.Find("Character").GetComponent<CharacterController>();
        InvokeRepeating("SpawnObstacle", delay, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle()
    {
        if (!characterController.isGameOver)
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}
