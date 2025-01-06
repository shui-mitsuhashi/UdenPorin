using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    public float RotationSpeed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, RotationSpeed, 0);
    }
}
