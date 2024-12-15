//画面側に側面を向けている歯車を回転させるスクリプト

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZBaseSearSpin : MonoBehaviour
{
    public float rotateSpeed = 60;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed, Space.World);
    }
}
