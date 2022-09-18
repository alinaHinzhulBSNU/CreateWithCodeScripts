using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour
{
    public GameObject car;
    private Vector3 offset = new Vector3(0, 5, -7); // camera offset

    void LateUpdate()
    {
        transform.position = car.transform.position + offset;    
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
