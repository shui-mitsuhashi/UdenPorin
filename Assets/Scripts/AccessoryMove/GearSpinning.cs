using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSpinning : MonoBehaviour
{
    public float rotationSpeed = 50f;

    public float moveRange = 2f; 
    public float moveSpeed = 2f; 

    private float initialY;

    void Start()
    {
        initialY = transform.position.y;
    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        float newY = initialY + Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
